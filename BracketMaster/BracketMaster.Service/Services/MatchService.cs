﻿using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Service
{
    public class MatchService<T> : IMatchService<T> where T : Match
    {
        readonly IMatchRepository<T> _matchRepository;
        readonly IMatchLogic<T> _matchLogic;

        public MatchService(IMatchRepository<T> matchRepository, IMatchLogic<T> matchLogic)
        {
            _matchRepository = matchRepository;
            _matchLogic = matchLogic;
        }

        public void Create(T item)
        {
            try
            {
                _matchLogic.Validate(item);
                _matchRepository.Create(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _matchRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public T Read(int id)
        {
            try
            {
                return _matchRepository.Read(id);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<T> ReadAll()
        {
            try
            {
                return _matchRepository.ReadAll();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public void Update(T item)
        {
            try
            {
                _matchLogic.Validate(item);
                _matchRepository.Update(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
