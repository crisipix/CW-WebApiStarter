using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Dos;
using WebExample.DataAccess.Repositories;
using WebExample.Models;

namespace WebExample.Services.Account
{
    public class AccountService : IAccountService
    {

        private IDictionary<int, string> Accounts;
        private BaseRepository<AccountDo> _acctRepository;
        private BaseRepository<PersonDo> _personRepository;
        public AccountService(BaseRepository<AccountDo> repository,
            BaseRepository<PersonDo> personRepository) {
            _acctRepository = repository;
            _personRepository =  personRepository;
           
        }
        public IEnumerable<AccountModel> GetAccounts() {
            var accountDos = _acctRepository.GetAll();
            return MapAccountOwners(accountDos);
        }

        public AccountModel GetAccountById(int id) {
            return MapAccountOwners(new List<AccountDo> { _acctRepository.Get(id) }).FirstOrDefault(); 
        }

        public AccountModel InsertAccount(AccountModel account)
        {
            var accountDo = Mapper.Map<AccountModel, AccountDo>(account);
            accountDo = _acctRepository.Insert(accountDo);
            //return Mapper.Map<AccountDo, AccountModel>(accountDo);

            return MapAccountOwners(new List<AccountDo> { accountDo }).FirstOrDefault();
        }

        public AccountModel UpdateAccount(AccountModel account)
        {
            var accountDo = Mapper.Map<AccountModel, AccountDo>(account);

            accountDo = _acctRepository.Update(accountDo);

            //return Mapper.Map<AccountDo, AccountModel>(accountDo);

            return MapAccountOwners(new List<AccountDo> { accountDo }).FirstOrDefault();

        }

        public bool DeleteAccount(int Id)
        {
            return _acctRepository.Delete(Id);
        }

        private IEnumerable<AccountModel> MapAccountOwners(IEnumerable<AccountDo> accountDos)
        {
            var accountModels = new List<AccountModel>();
            var personModels = Mapper.Map<IEnumerable<PersonDo>, IEnumerable<PersonModel>>(_personRepository.GetAll());
            var personCache = personModels.ToDictionary(x => x.Id, y => y);

            foreach (var accountDo in accountDos)
            {
                var accountModel = Mapper.Map<AccountDo, AccountModel>(accountDo);
                //var person = Mapper.Map<PersonDo, PersonModel>(_personRepository.Get(accountDo.OwnerId));
                accountModel.Owner = personCache[accountDo.OwnerId];
                accountModels.Add(accountModel);
            }
            return accountModels;
        }
    }
}