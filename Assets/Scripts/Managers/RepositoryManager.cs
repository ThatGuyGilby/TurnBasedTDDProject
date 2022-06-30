using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositoryManager
{
    #region Public Fields

    public static Repository<AttributeData> attributeDataRepository = new Repository<AttributeData>(Constants.ATTRIBUTE_DATA_PATH);
    public static Repository<MoveData> moveDataRepository = new Repository<MoveData>(Constants.MOVE_DATA_PATH);
    public static Repository<SpeciesData> speciesDataRepository = new Repository<SpeciesData>(Constants.SPECIES_DATA_PATH);

    #endregion Public Fields

    #region Public Properties

    public static RepositoryManager Instance { get; private set; }

    #endregion Public Properties
}