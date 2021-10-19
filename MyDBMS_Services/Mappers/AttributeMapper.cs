using MyDBMS.Dtos;
using MyDBMS.Models;

namespace DBMSServices.Mappers
{
    public class AttributeMapper
    {
        public Attribute MapToAttribute(AttributeDto dto)
        {
            var attribute = new Attribute()
            {
                Id = dto.Id,
                Name = dto.Name,
                TypeName = dto.TypeName,
                TableId = dto.TableId
            };

            return attribute;
        }

        public AttributeDto MapToAttributeDto(Attribute attribute)
        {
            var attributeDto = new AttributeDto()
            {
                Id = attribute.Id,
                Name = attribute.Name,
                TableId = attribute.TableId,
                TypeName = attribute.TypeName
            };

            return attributeDto;
        }
    }
}