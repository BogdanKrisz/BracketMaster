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
    public class GroupService<T> : IGroupService<T>
        where T : Group
    {
        readonly IGroupRepository<T> _groupRepository;
        readonly IGroupLogic<T> _groupLogic;

        public GroupService(IGroupRepository<T> groupRepository, IGroupLogic<T> groupLogic)
        {
            _groupRepository = groupRepository;
            _groupLogic = groupLogic;
        }

        public void Create(T item)
        {
            try
            {
                _groupLogic.Validate(item);
                _groupRepository.Create(item);
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
                _groupRepository.Delete(id);
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
                return _groupRepository.Read(id);
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
                return _groupRepository.ReadAll();
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
                _groupLogic.Validate(item);
                _groupRepository.Update(item);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
