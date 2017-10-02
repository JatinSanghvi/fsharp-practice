(*
Diagonal Difference

Given a square matrix of size N x N, calculate the absolute difference between the sums of its diagonals.

Input Format

The first line contains a single integer, N. The next N lines denote the matrix's rows, with each line containing N space-
separated integers describing the columns.

Constraints

-100 <= Elements in the matrix <= 100

Output Format

Print the absolute difference between the two sums of the matrix's diagonals as a single integer.

Sample Input

3
11 2 4
4 5 6
10 8 -12

Sample Output

15

Explanation

The primary diagonal is:

11
   5
     -12
Sum across the primary diagonal: 11 + 5 - 12 = 4

The secondary diagonal is:

     4
   5
10
Sum across the secondary diagonal: 4 + 5 + 10 = 19 
Difference: |4 - 19| = 15

Note: |x| is absolute value function
*)

open System

[<EntryPoint>]
let main _ =
    let size = Console.ReadLine() |> int
    let matrix = List.init size (fun _ -> Console.ReadLine().Split [|' '|] |> Array.toList |> List.map int)

    let rec diagonal_sum matrix =
        let sub_matrix matrix =
            match matrix with
            | row :: rows -> List.map(fun row ->
                match row with
                | cell :: cells -> cells
                | _ -> raise (new InvalidOperationException("Invalid row"))) rows
            | _ -> raise (new InvalidOperationException("Invalid matrix"))

        match matrix with
        | [] -> 0
        | [[cell]] -> cell
        | (cell :: _) :: rows -> cell + diagonal_sum (sub_matrix matrix)
        | _ -> raise (new InvalidOperationException("Invalid matrix"))

    let diagonal_difference = abs ((diagonal_sum matrix) - (diagonal_sum (List.rev matrix)))
    printfn "%d" diagonal_difference
    0