[<AutoOpen>]
module SFX.ROP.Types

// the two-track type
type Result<'TSuccess,'TFailure> = 
    | Success of 'TSuccess
    | Failure of 'TFailure