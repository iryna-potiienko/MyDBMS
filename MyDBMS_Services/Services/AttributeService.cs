using System.Collections.Generic;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace DBMSServices.Services
{
    public class AttributeService
    {
        private readonly AttributeRepository _attributeRepository;

        public AttributeService(AttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public Attribute Create(Attribute attribute)
        {
            var createdAttribute = _attributeRepository.Create(attribute);
            return createdAttribute.Result;
        }

        public List<Attribute> GetAll()
        {
            return _attributeRepository.FindAll()
                .Result;
        }

        public Attribute Get(int id)
        {
            var attribute = _attributeRepository.FindById(id);
            return attribute;
        }

        public bool Edit(int id, Attribute attribute)
        {
            var oldAttribute = _attributeRepository.FindById(id);

            if (oldAttribute == null)
            {
                return true;
            }

            oldAttribute.Name = attribute.Name;
            oldAttribute.Type = attribute.Type;
            oldAttribute.TableId = attribute.TableId;

            _attributeRepository.Update(oldAttribute);
            return false;
        }

        public bool Delete(int id)
        {
            var attribute = _attributeRepository.FindById(id);

            if (attribute == null)
            {
                return false;
            }

            _attributeRepository.Delete(attribute);
            return true;
        }

        public List<Attribute> GetByTableId(int tableId)
        {
            var list = _attributeRepository.GetByTableId(tableId);
            return list;
        }
    }
}