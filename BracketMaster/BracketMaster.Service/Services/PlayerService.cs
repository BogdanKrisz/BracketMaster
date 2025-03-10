using BracketMaster.Logic;
using BracketMaster.Models;
using BracketMaster.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Service
{
    public class PlayerService<T, G, M> : IPlayerService<T, G, M>
        where T : Player
        where G : Group
        where M : Match
    {
        readonly IPlayerRepository<T> _playerRepository;
        readonly IPlayerLogic<T> _playerLogic;

        readonly IGroupService<G> _groupService;
        readonly IMatchService<M> _matchService;

        public PlayerService(
            IPlayerRepository<T> playerRepository,
            IPlayerLogic<T> playerLogic,
            IGroupService<G> groupService,
            IMatchService<M> matchService)
        {
            _playerRepository = playerRepository;
            _playerLogic = playerLogic;
            _matchService = matchService;
            _groupService = groupService;
        }



        public void Create(T item)
        {
            try
            {
                _playerLogic.Validate(item);
                _playerRepository.Create(item);
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
                _playerRepository.Delete(id);
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
                return _playerRepository.Read(id);
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
                return _playerRepository.ReadAll();
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
                _playerLogic.Validate(item);
                _playerRepository.Update(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
