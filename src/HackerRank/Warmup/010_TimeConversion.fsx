(*
Given a time in 12-hour AM/PM format, convert it to military (24-hour) time.

Note: Midnight is 12:00:00AM on a 12-hour clock, and 00:00:00 on a 24-hour clock. Noon is 12:00:00PM on a 12-hour clock,
and 12:00:00 on a 24-hour clock.

Input Format

A single string containing a time in 12-hour clock format (i.e.: hh:mm:ssAM or hh:mm:ssPM), where 01 <= hh <= 12 and
00 <= mm <= 59.

Output Format

Convert and print the given time in 24-hour format, where 00 <= hh <= 23.

Sample Input

07:05:45PM

Sample Output

19:05:45
*)

open System

[<EntryPoint>]
let main _ =
    let time12 = Console.ReadLine();

    let hour = (time12.Substring(0, 2) |> int) % 12;
    let hour = if time12.[8] = 'A' then hour else hour + 12;

    printfn "%02d%s" hour (time12.Substring(2, 6))
    0