public class RepositoryManager
{
    public static Repository<AttributeData> attributeDataRepository = new Repository<AttributeData>(Constants.ATTRIBUTE_DATA_PATH);
    public static Repository<MoveData> moveDataRepository = new Repository<MoveData>(Constants.MOVE_DATA_PATH);
    public static Repository<SpeciesData> speciesDataRepository = new Repository<SpeciesData>(Constants.SPECIES_DATA_PATH);
    public static Repository<WeatherData> weatherDataRepository = new Repository<WeatherData>(Constants.WEATHER_DATA_PATH);

    public static RepositoryManager Instance { get; private set; }
}