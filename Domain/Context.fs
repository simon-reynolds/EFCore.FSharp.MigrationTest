namespace MigrationTest

open Microsoft.EntityFrameworkCore
open MigrationTest.Domain

open Bricelam.EntityFrameworkCore.FSharp
open System.ComponentModel.DataAnnotations

type SchoolContext (options) = 
    inherit DbContext (options)

    [<DefaultValue>] val mutable students : DbSet<Student>
    member __.Students with get() = __.students and set v = __.students <- v
    [<DefaultValue>] val mutable enrollments : DbSet<Enrollment>
    member __.Enrollment with get() = __.enrollments and set v = __.enrollments <- v
    [<DefaultValue>] val mutable courses : DbSet<Course>
    member __.Courses with get() = __.courses and set v = __.courses <- v

    override __.OnModelCreating mb =
        mb.Entity<Student>().Property(fun s -> s.MiddleName).HasConversion(OptionConverter<string> ()) |> ignore

        mb.Entity<Enrollment>().HasIndex("CourseId", "StudentId").IsUnique(true) |> ignore

        ()
