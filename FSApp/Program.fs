// Learn more about F# at http://fsharp.org

open System
open AppData
open System.Collections

[<EntryPoint>]
let main argv =
    printfn "Adding data to Postgres DB."

    use ctx = new PGContext()
    let user = User()
    user.Id <- Guid()
    user.FirstName <- "Sandeep"
    user.LastName <- "Chandra"
    user.DOB <- Nullable(DateTime.Parse("10 Jan 1986"))

    let newAddress = Address()
    newAddress.Id <- Guid()
    newAddress.Number <- "5"
    newAddress.Street <- "My Street"
    newAddress.Suburb <- "My Suburb"
    newAddress.City <- "My City"
    newAddress.Country <- "My Country"
    user.Addresses.Add newAddress
    
    ctx.Add(user) |> ignore
    ctx.SaveChanges() |> ignore
    printfn "Finished adding data to Postgres DB."
    0 // return an integer exit code
