using SWStarships.Services.ValueObjects.Enum;

namespace SWStarships.Services.ValueOfObjects.Enum
{
    public class HoursInConsumablesEnum : BaseEnum<HoursInConsumablesEnum, string>
    {
        public static HoursInConsumablesEnum DAY = new HoursInConsumablesEnum(24, "day");
        public static HoursInConsumablesEnum DAYS = new HoursInConsumablesEnum(24, "days");
        public static HoursInConsumablesEnum WEEK = new HoursInConsumablesEnum(168, "week");
        public static HoursInConsumablesEnum WEEKS = new HoursInConsumablesEnum(168, "weeks");
        public static HoursInConsumablesEnum MONTH = new HoursInConsumablesEnum(730, "month");
        public static HoursInConsumablesEnum MONTHS = new HoursInConsumablesEnum(730, "months");
        public static HoursInConsumablesEnum YEAR = new HoursInConsumablesEnum(8760, "year");
        public static HoursInConsumablesEnum YEARS = new HoursInConsumablesEnum(8760, "years");

        protected HoursInConsumablesEnum(int codigo, string valor) : base(codigo, valor) { }
    }
}
