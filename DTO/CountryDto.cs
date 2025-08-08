namespace DTO
{
    public class CountryDto
    {
        public class Http
        {
            public CountryName Name { get; set; }
            public CountryTranslations Translations { get; set; }
            public CountryFlags Flags { get; set; }
            public CountryMaps Maps { get; set; }
            public string Cca2 { get; set; }

            public class CountryName
            {
                public string Common { get; set; }
            }

            public class CountryTranslations
            {
                public Translation Rus { get; set; }

                public class Translation
                {
                    public string Common { get; set; }
                }
            }

            public class CountryFlags
            {
                public string Png { get; set; }
            }

            public class CountryMaps
            {
                public string GoogleMaps { get; set; }
            }
        }

        public class Key
        {
            public int Id { get; set; }
        }

        public class List : Key
        {
            public string Name { get; set; }
        }
    }
}
