using System.Collections.Generic;
using System.Threading.Tasks;
using DBMSServices.Mappers;
using MyDBMS.Dtos;
using MyDBMS.Models;
using MyDBMS.Repositories;

namespace DBMSServices.Services
{
    public class AttributeService
    {
        private readonly AttributeRepository _attributeRepository;
        private readonly AttributeMapper _attributeMapper;

        public AttributeService(AttributeRepository attributeRepository, AttributeMapper attributeMapper)
        {
            _attributeRepository = attributeRepository;
            _attributeMapper = attributeMapper;
        }

        public async Task<AttributeDto> Create(AttributeDto attributeDto)
        {
            var attribute = _attributeMapper.MapToAttribute(attributeDto);
            var createdAttribute = await _attributeRepository.Create(attribute);
            return _attributeMapper.MapToAttributeDto(createdAttribute);
            //return createdAttribute;
        }

        public async Task<List<AttributeDto>> GetAll()
        {
            var found = await _attributeRepository.FindAll();
            return found.ConvertAll(input => _attributeMapper.MapToAttributeDto(input));
            // return _attributeRepository.FindAll().Result
            //     .ConvertAll(input => _attributeMapper.MapToAttributeDto(input));
        }

        public async Task<AttributeDto> Get(int id)
        {
            var attribute = await _attributeRepository.FindById(id);
            return attribute != null ? _attributeMapper.MapToAttributeDto(attribute) : null;
        }

        public async Task<bool> Edit(int id, AttributeDto attributeDto)
        {
            var oldAttribute = await _attributeRepository.FindById(id);

            if (oldAttribute == null)
            {
                return false;
            }

            if (!_attributeRepository.TableExist(attributeDto.TableId))
            {
                return false;
            }
            var type = await _attributeRepository.TypeExist(attributeDto.TypeName);
            if (type == null)
            {
                return false;
            }
            
            oldAttribute.Name = attributeDto.Name;
            oldAttribute.TypeName = attributeDto.TypeName;
            oldAttribute.TableId = attributeDto.TableId;

            _attributeRepository.Update(oldAttribute);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var attribute = await _attributeRepository.FindById(id);

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