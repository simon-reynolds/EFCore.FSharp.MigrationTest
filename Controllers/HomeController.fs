namespace MigrationTest.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open MigrationTest
open MigrationTest.Domain

type HomeController (context: SchoolContext) =
    inherit Controller()
    
    let updateStudent (context: SchoolContext) (entity: Student) = 
        let currentEntry = context.Students.Find(entity.Id)
        context.Entry(currentEntry).CurrentValues.SetValues(entity)
        context.SaveChanges |> ignore

    member this.Index () =

        // let student1 = {
        //     Id = 1
        //     LastName = "Taite"
        //     MiddleName = Some "A"
        //     FirstName = "Simon"
        //     EnrollmentDate = DateTime.UtcNow
        //     Enrollments = [||]
        // }

        // let student2 = {
        //     Id = 2
        //     LastName = "Stark"
        //     MiddleName = None
        //     FirstName = "Eddard"
        //     EnrollmentDate = DateTime.UtcNow
        //     Enrollments = [||]
        // }

        // [| student1; student2 |] |> context.Students.AddRange |> ignore
        // context.SaveChanges() |> ignore

        this.View()

    member this.About () =

        let q = query {
            for s in context.Students do
            where s.MiddleName.IsSome
            select s
        }

        let result = q |> Seq.head
        printfn "Result: %A" result

        
        let update = { result with LastName = "Baratheon"; MiddleName = Some "B"; FirstName = "Bobby" }
        updateStudent context update
        
        printfn "Result: %A" update

        this.ViewData.["Message"] <- (string result)
        this.View()

    member this.Contact () =
        this.ViewData.["Message"] <- "Your contact page."
        this.View()

    member this.Error () =
        this.View();
