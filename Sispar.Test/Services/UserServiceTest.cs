using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sispar.Business.Services;
using Sispar.Core.Contracts;
using Sispar.Core.Entities;
using Sispar.Common.Helpers;
using System.Threading.Tasks;

namespace Sispar.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        [TestCategory("Services")]
        public void Login_Valid()
        {
            // arrange
            var context = new UserService(new UserRepoFake());

            // act
            var result = context.Login("felipe", "123456");

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Active);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Login_Username_NotFound()
        {
            // arrange
            var context = new UserService(new UserRepoFake());

            // act
            var result = context.Login("joao", "123456");

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Login_Wrong_Password()
        {
            // arrange
            var context = new UserService(new UserRepoFake());

            // act
            var result = context.Login("felipe", "123466");

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Login_Inactive_User()
        {
            // arrange
            var context = new UserService(new UserRepoFake());

            // act
            var result = context.Login("milton", "123456");

            // assert
        }

        [TestMethod]
        public void ChangePassword_Valid()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.ChangePassword("felipe", "123456", "2222", "2222");
            var result = userRepo.GetByUserName("felipe");

            // assert            
            Assert.IsNotNull(result);
            Assert.AreEqual("2222".Encrypt(), result.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChangePassword_Password_ConfirmPassword_Differents()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.ChangePassword("felipe", "123456", "2222", "2223");
            var result = userRepo.GetByUserName("felipe");

            // assert            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChangePassword_Password_Empty()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.ChangePassword("felipe", "123456", "", "2222");
            var result = userRepo.GetByUserName("felipe");

            // assert            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChangePassword_Password_Null()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.ChangePassword("felipe", "123456", null, "2222");
            var result = userRepo.GetByUserName("felipe");

            // assert            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChangePassword_ConfirmPassword_Empty()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.ChangePassword("felipe", "123456", "2222", "");
            var result = userRepo.GetByUserName("felipe");

            // assert            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChangePassword_ConfirmPassword_Null()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.ChangePassword("felipe", "123456", "2222", null);
            var result = userRepo.GetByUserName("felipe");

            // assert            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePassword_User_NotFound()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.ChangePassword("Joao", "123456", "2222", "2222");

            // assert            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePassword_Wrong_Password()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.ChangePassword("Felipe", "123455", "2222", "2222");

            // assert            
        }

        [TestMethod]
        public void Register_Valid()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.Register("Joao", "123456", "123456");
            var result = userRepo.GetByUserName("Joao");

            // assert            
            Assert.IsNotNull(result);
            Assert.AreEqual("123456".Encrypt(), result.Password);
            Assert.AreEqual(true, result.Active);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Register_Duplicate_User()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.Register("felipe", "123456", "123456");

            // assert            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Register_Password_ConfirmPassword_Differents()
        {
            // arrange
            var userRepo = new UserRepoFake();
            var context = new UserService(userRepo);

            // act
            context.Register("joao", "123456", "123455");

            // assert            
        }

    }


    public class UserRepoFake: IUserRepository
    {
        private readonly List<User> _repo;

        public UserRepoFake()
        {
            _repo = new List<User>() {
                    new User(){ Id = Guid.NewGuid(), Username = "felipe", Password = "123456".Encrypt() , Active = true},
                    new User(){ Id = Guid.NewGuid(), Username = "milton", Password = "123456".Encrypt() , Active = false}
                };
        }

        public void Add(User obj)
        {
            _repo.Add(obj);
        }

        public void Delete(User obj)
        {
            _repo.Remove(obj);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Edit(User obj)
        {
            var user = _repo.Where(x => x.Id == obj.Id).FirstOrDefault();
            if (user != null)
            {
                user.Username = obj.Username;
                user.Password = obj.Password;
                user.Active = obj.Active;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _repo.ToArray();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            return _repo.Where(x => x.Id == id).FirstOrDefault();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUserName(string userName)
        {
            return _repo.Where(x => x.Username == userName).FirstOrDefault();
        }

        public Task<User> GetByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
