using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MyDBMS.Models;

namespace DBMSServices.Services
{
    public class ValidateService
    {
        private readonly AttributeService _attributeService;

        public ValidateService(AttributeService attributeService)
        {
            _attributeService = attributeService;
        }

        public async Task<bool> ValidateCell(Cell cell)
        {
            var attributeId = Convert.ToInt32(cell.AttributeId);
            var attribute = await _attributeService.Get(attributeId);

            var typeName = attribute.TypeName;
            var data = cell.Data;
            
            bool typeOK = false;
            switch (typeName)
            {
                case "integer":
                {
                    int numb;
                    typeOK=Int32.TryParse(data, out numb);
                    break;
                }
                case "real":
                {
                    double d;
                    typeOK = Double.TryParse(data, out d);
                    break;
                }
                case "char":
                {
                    char ch;
                    typeOK = Char.TryParse(data, out ch);
                    break;
                }
                case "string":
                    typeOK = true;
                    break;
                case "charInvl":
                {
                    string pattern = @"^\s*\(\s*[a-z]\s*[,;]\s*[a-z]\s*\)\s*$";
                    typeOK = Regex.IsMatch(data, pattern, RegexOptions.IgnoreCase);
                    break;
                }
                // case "string(charInvl)":
                // {
                //     
                // }
            }
            return typeOK;
        }
    }
}