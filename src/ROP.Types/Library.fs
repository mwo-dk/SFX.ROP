namespace SFX.ROP

[<AutoOpen>]
module Types =

    // the two-track type
    type Result<'TSuccess,'TFailure> = 
    | Success of 'TSuccess
    | Failure of 'TFailure

    type PartialFailure<'TSuccess, 'TFailure> = 
        {
            Successes: 'TSuccess array
            Failures: 'TFailure array
        }
    type ResultSummary<'TSuccess, 'TFailure> =
    | Empty
    | Partial of PartialFailure<'TSuccess, 'TFailure>
    | Full  of 'TFailure array