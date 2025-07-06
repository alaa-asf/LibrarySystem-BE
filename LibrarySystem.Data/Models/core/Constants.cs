namespace LibrarySystem.Data.Models.core
{
    public static partial class Constants
    {
        public const int PAGE_NUMBER = 0;
        public const int PAGE_SIZE = 10;
        public const int MAX_PAGE_SIZE = 1000;
        private const string MAJOR_VERSION = "1";
        private const string MINOR_VERSION = "0";
        public const string API_VERSION = $"{MAJOR_VERSION}.{MINOR_VERSION}";
        public const string VERSION = MAJOR_VERSION;


    }
    public static class Errors
    {

        public const string ValidationError = "validation_error";
        public const string BadCredentials = "bad_credentials";
        public const string UnknowingTargetProgram = "unknowing_target_program";
        public const string UnauthorizedUser = "unauthorized_user";
        public const string FailedToAuthorize = "failed_to_authorize";
        public const string ProgramDoesNotSupportThisTypeOfPermissions = "this_program_does_not_support_this_type_of_permissions";
        public const string ConcurrencyErrorPleaseRefresh = "concurrency_error_please_refresh";
        public const string NotFound = "not_found";
        public const string PleaseProvideAccessToken = "please_provide_access_token";
        public const string YouDoNotHavePermission = "you_do_not_have_permission";
        public const string youCanNotUpdatePollAfterBeingOpenForVoting = "you_can_not_update_poll_after_being_open_for_voting";

    }

    public static class ValidationMessages
    {

        public const string NotEmpty = "can_not_be_empty";
        public const string IsDateOnly = "must_be_dateonly";
        public const string IsDateTime = "must_be_datetime";
        public const string ForigenKey = "is_not_exist";
        public const string IsBeforeToDate = "must_be_before_ToDate";
        public const string IsAfterFromDate = "must_be_after_FromDate";
        public const string IsBeforeDueDate = "must_be_before_DueDate";
        public const string IsAfterStartDate = "must_be_after_StartDate";
        public const string MinLength = "length_must_be_maximum";
        public const string MaxLength = "length_must_be_minimum ";
        public const string NotFutureDate = "must_not_be_a_future_date";
        public const string IsInactiveCommittee = "is_only_valid_if_the_committee_is_inactive";
        public const string IsActiveCommittee = "is_only_valid_if_the_committee_is_active";
    }
}
