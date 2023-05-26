using System.ComponentModel;
using System.Text.RegularExpressions;

namespace GasStation.Domain.View
{
    public class RegistrationMarkViewModel : IDataErrorInfo
    {
        public string Number { get; set; } = string.Empty;
        public string RegionNumber { get; set; } = string.Empty;
        public string Country { get; set; } = "RUS";

        /// <summary>
        /// Та самая картинка
        /// </summary>
        public byte[] CorrectImage { get; set; }

        /// <summary>
        /// картинки для выбора
        /// </summary>
        public List<byte[]> AvaibleImages { get; set; }

        public string this[string columnName]
        {
            get
            {
                var error = string.Empty;

                switch (columnName)
                {
                    case "Number":
                        {
                            if (!Regex.IsMatch(Number, @"^[A-Z]\d{3}[A-Z]{2}"))
                                error = "номер не правильный";
                            break;
                        }

                    case "RegionNumber":
                        {
                            if (!Regex.IsMatch(RegionNumber, @"\d{2}"))
                                error = "регион должен быть только в числах";

                            break;
                        }

                    case "Country":
                        {
                            break;
                        }
                }

                return error;
            }
        }

        public string Error => throw new NotImplementedException();
    }
}
