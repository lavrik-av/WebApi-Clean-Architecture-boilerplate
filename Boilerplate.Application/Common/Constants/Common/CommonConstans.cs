﻿namespace Boilerplate.Application.Common.Constants.Common
{
    public abstract class CommonConstans
    {
        //Common constants
        public const string SOMETHING_WENT_WRONG = nameof(SOMETHING_WENT_WRONG);
        public const string BASE_APPLICATION_EXCEPTION = nameof(BASE_APPLICATION_EXCEPTION);
        public const string NOT_FOUND_EXCEPTION = nameof(NOT_FOUND_EXCEPTION);
        public const string UNEXPECTED_ERROR = nameof(UNEXPECTED_ERROR);
        public const string MISSING_REQUIRED_FIELDS = nameof(MISSING_REQUIRED_FIELDS);
        public const string ENTITY_NOT_FOUND = nameof(ENTITY_NOT_FOUND);

        // Model constants
        public const string MODEL_ID = nameof(MODEL_ID);
        public const string MODEL_ID_GUID_BAD_FORMAT = nameof(MODEL_ID_GUID_BAD_FORMAT);
        public const string ENTITY_TYPE_PRODUCT = nameof(ENTITY_TYPE_PRODUCT);

        //Entities consstants
        public const string ENTITY_ENTITY_NAME = nameof(ENTITY_ENTITY_NAME);
        public const string ENIITY_FIELD_NAME = nameof(ENIITY_FIELD_NAME);

        // CRUD operations constants
        public const string OPERATION_DELETE = nameof(OPERATION_DELETE);
        public const string OPERAION_UPDATE = nameof(OPERAION_UPDATE);
        public const string OPERAION_GET_PRODUCT = nameof(OPERAION_GET_PRODUCT);

        // DB errors
        public const string UNEXPECTED_DB_ERROR = nameof(UNEXPECTED_DB_ERROR);
        public const string CREATING_ENTITY_DB_ERROR = nameof(CREATING_ENTITY_DB_ERROR);

        //Expression Tree
        public const string EXPRESSION_TREE_ERROR = nameof(EXPRESSION_TREE_ERROR);

        // Search errors
        public const string SEARCH_ERROR = nameof(SEARCH_ERROR);
        public const string SEARCH_ERROR_WRONG_PARAMETERS_VALUE = nameof(SEARCH_ERROR_WRONG_PARAMETERS_VALUE);
        public const string SEARCH_ERROR_FIELD_DOES_NOT_EXIST_ON_ENTITY_TABLE = nameof(SEARCH_ERROR_FIELD_DOES_NOT_EXIST_ON_ENTITY_TABLE);
        public const string SEARCH_ERROR_PARAMS_COMPARATOR = nameof(SEARCH_ERROR_PARAMS_COMPARATOR);
    }
}
