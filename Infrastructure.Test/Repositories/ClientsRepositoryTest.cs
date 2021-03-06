using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kaizen.Domain.Data;
using Kaizen.Domain.Entities;
using Kaizen.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Infrastructure.Test.Repositories
{
    [TestFixture]
    [Order(0)]
    public class ClientsRepositoryTest : BaseRepositoryTest
    {
        private IClientsRepository clientsRepository;
        private ApplicationDbContext dbContext;

        [SetUp]
        public void InitRepository()
        {
            DetachAllEntities();

            clientsRepository = ServiceProvider.GetService<IClientsRepository>();
            dbContext = ServiceProvider.GetService<ApplicationDbContext>();
        }

        [Test]
        public void CheckClientRepository()
        {
            Assert.IsNotNull(clientsRepository);
        }

        [Test]
        public async Task CheckClientTableAreEmpty()
        {
            List<Client> clients = await clientsRepository.GetAll().ToListAsync();

            Assert.IsTrue(clients.Count == 0);
        }

        [Test]
        public void SaveEmptyClient()
        {
            try
            {
                Client client = new Client();
                clientsRepository.Insert(client);
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task SaveClient()
        {
            try
            {
                Client client = new Client
                {
                    Id = "12345678",
                    FirstName = "Manolo",
                    LastName = "Perez",
                    FirstPhoneNumber = "3167040706",
                    ClientType = "Natural Person",
                    ClientAddress = new ClientAddress
                    {
                        City = "Valledupar",
                        Neighborhood = "El centro",
                        Street = "Calle 9",
                        ClientId = "12345678"
                    },
                    ContactPeople = new List<ContactPerson>
                    {
                        new ContactPerson
                        {
                            Name = "Jesus Guerrero",
                            PhoneNumber = "3163100223",
                            ClientId = "12345678"
                        }
                    }
                };

                clientsRepository.Insert(client);

                await dbContext.SaveChangesAsync();

                Assert.Pass();
            }
            catch (DbUpdateException)
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task SearchClient()
        {
            try
            {
                Client client = await clientsRepository.FindByIdAsync("12345678");
                Assert.IsNotNull(client);
                Assert.AreEqual("12345678", client.Id);
                Assert.AreEqual("Manolo", client.FirstName);
            }
            catch (DbUpdateException)
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task UpdateClient()
        {
            try
            {
                Client client = await clientsRepository.FindByIdAsync("12345678");
                Assert.IsNotNull(client);

                client.SecondName = "Jesus";
                clientsRepository.Update(client);

                await dbContext.SaveChangesAsync();

                client = await clientsRepository.FindByIdAsync("12345678");
                Assert.AreEqual("Jesus", client.SecondName);
            }
            catch (DbUpdateException)
            {
                Assert.Fail();
            }
        }
    }
}
