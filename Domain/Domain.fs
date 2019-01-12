namespace MigrationTest

open System
open System.Collections.Generic
open System.ComponentModel.DataAnnotations

module rec Domain =

    [<CLIMutable>]
    type Student = {
        [<Key>]
        Id : int
        LastName: string
        MiddleName: string option
        FirstName: string
        
        EnrollmentDate: DateTime
        
        Enrollments: ICollection<Enrollment>
    }
    
    [<CLIMutable>]
    type Enrollment = {
        [<Key>]
        Id: int
        CourseId: int
        StudentId: int

        Grade: char

        Course: Course
        Student: Student
    }
    
    [<CLIMutable>]
    type Course = {
        [<Key>]
        Id: int
        
        [<MaxLength(150)>]
        Title: string
        Credits: int

        Enrollments: ICollection<Enrollment>
    }