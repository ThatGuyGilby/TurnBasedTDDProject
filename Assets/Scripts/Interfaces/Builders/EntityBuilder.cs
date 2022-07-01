public class EntityBuilder : IBuilder<Entity>
{
    #region Private Fields

    private int level;
    private string nickname;
    private SpeciesKey speciesKey;

    #endregion Private Fields

    #region Public Constructors

    public EntityBuilder()
    {
        this.nickname = "";
        this.level = 1;
        this.speciesKey = SpeciesKey.CHARMANDER;
    }

    #endregion Public Constructors

    #region Public Methods

    public Entity Build()
    {
        EntityData entityData = new EntityDataBuilder().WithNickname(nickname).WithLevel(level).WithSpecies(speciesKey).Build();

        return new Entity(entityData);
    }

    public EntityBuilder WithLevel(int level)
    {
        this.level = level;
        return this;
    }

    public EntityBuilder WithNickname(string nickname)
    {
        this.nickname = nickname;
        return this;
    }

    public EntityBuilder WithSpecies(SpeciesKey speciesKey)
    {
        this.speciesKey = speciesKey;
        return this;
    }

    #endregion Public Methods
}