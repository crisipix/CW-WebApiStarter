using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using $safeprojectname$.Repositories.Dos;
using $safeprojectname$.Repositories;
using $safeprojectname$.Models;

namespace $safeprojectname$.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private BaseRepository<AccountDo> _acctRepository;
        private BaseRepository<PersonDo> _personRepository;
        public AccountService(
            IMapper mapper,
            BaseRepository<AccountDo> repository,
            BaseRepository<PersonDo> personRepository) {
            _mapper = mapper;
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
            var accountDo = _mapper.Map<AccountModel, AccountDo>(account);
            accountDo = _acctRepository.Insert(accountDo);

            return MapAccountOwners(new List<AccountDo> { accountDo }).FirstOrDefault();
        }

        public AccountModel UpdateAccount(AccountModel account)
        {
            var accountDo = _mapper.Map<AccountModel, AccountDo>(account);

            accountDo = _acctRepository.Update(accountDo);

            return MapAccountOwners(new List<AccountDo> { accountDo }).FirstOrDefault();

        }

        public bool DeleteAccount(int Id)
        {
            return _acctRepository.Delete(Id);
        }

        private IEnumerable<AccountModel> MapAccountOwners(IEnumerable<AccountDo> accountDos)
        {
            var accountModels = new List<AccountModel>();
            var personModels = _mapper.Map<IEnumerable<PersonDo>, IEnumerable<PersonModel>>(_personRepository.GetAll());
            var personCache = personModels.ToDictionary(x => x.Id, y => y);

            foreach (var accountDo in accountDos)
            {
                var accountModel = _mapper.Map<AccountDo, AccountModel>(accountDo);
                accountModel.Owner = personCache[accountDo.OwnerId];
                accountModels.Add(accountModel);
            }
            return accountModels;
        }
    }
}