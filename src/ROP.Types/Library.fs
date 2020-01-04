namespace SFX.ROP

[<AutoOpen>]
module Types =

    /// The two-track type
    type Result<'TSuccess,'TFailure> = 
    | Success of 'TSuccess
    | Failure of 'TFailure

    /// Represents a combination of successes and failures. Used when partitioning
    /// multiple Result<,>s
    type PartialFailure<'TSuccess, 'TFailure> = 
        {
            Successes: 'TSuccess array
            Failures: 'TFailure array
        }
    /// Represents the summary of multiple Result<,>s. 
    /// Empty means that no results were present
    /// Partial means, that there is a combination of successes and failures
    /// Full means that everything failed
    type ResultSummary<'TSuccess, 'TFailure> =
    | Empty
    | Partial of PartialFailure<'TSuccess, 'TFailure>
    | Full  of 'TFailure array