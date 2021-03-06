using System.Threading;
using System.Threading.Tasks;
using Kaizen.Core.Services;
using Kaizen.Domain.Entities;
using Kaizen.Domain.Events;
using Kaizen.Domain.Repositories;
using Kaizen.Extensions;
using Kaizen.Hubs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;

namespace Kaizen.DomainEvents.Handlers
{
    public class OnSavedPerson
    {
        public class Handler : INotificationHandler<DomainEventNotification<SavedPerson>>
        {
            private readonly IApplicationUserRepository _applicationUserRepository;
            private readonly IMailService _mailService;
            private readonly IHubContext<ClientHub> _clientHub;
            private readonly IMailTemplate _mailTemplate;
            private readonly IStatisticsRepository _statisticsRepository;
            private readonly IHttpContextAccessor _accessor;
            private readonly LinkGenerator _generator;

            public Handler(IMailService mailService, IHubContext<ClientHub> clientHub, IMailTemplate mailTemplate, IApplicationUserRepository applicationUserRepository,
                IStatisticsRepository statisticsRepository, IHttpContextAccessor accessor, LinkGenerator generator)
            {
                _mailService = mailService;
                _clientHub = clientHub;
                _mailTemplate = mailTemplate;
                _statisticsRepository = statisticsRepository;
                _accessor = accessor;
                _generator = generator;
                _applicationUserRepository = applicationUserRepository;
            }

            public async Task Handle(DomainEventNotification<SavedPerson> notification, CancellationToken cancellationToken)
            {
                Client savedClient = notification.DomainEvent.Client;

                await SendConfirmationEmail(savedClient);
                await NotifyNewClientRegister(cancellationToken);
                await RegisterNewClient();
            }

            private async Task SendConfirmationEmail(Client client)
            {
                string emailConfirmationToken = await _applicationUserRepository.GenerateEmailConfirmationTokenAsync(client.User);
                string emailConfirmationLink = _generator.GetUriByAction(_accessor.HttpContext, "ConfirmEmail", "user",
                    new { token = emailConfirmationToken.Base64ForUrlEncode(), email = client.User.Email });

                string emailMessage = _mailTemplate.LoadTemplate("NewClient.html", $"{client.FirstName} {client.LastName}",
                                                          $"{client.TradeName}", $"{client.ClientAddress.City}",
                                                          $"{client.ClientAddress.Neighborhood}", $"{client.ClientAddress.Street}",
                                                          $"{emailConfirmationLink}");

                await _mailService.SendEmailAsync(client.User.Email, "Cliente Registrado", emailMessage, true);
            }

            private async Task NotifyNewClientRegister(CancellationToken cancellationToken)
            {
                await _clientHub.Clients.Groups("Administrator", "OfficeEmployee").SendAsync("NewPersonRequest", cancellationToken: cancellationToken);
            }

            private async Task RegisterNewClient()
            {
                await _statisticsRepository.RegisterNewClientRegister();
            }
        }
    }
}
