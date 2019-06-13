#light

//
// <<Fnu Nousheerwan>>
// U. of Illinois, Chicago
// CS 341, Fall 2018
// Project #05: Language prediction based on letter frequencies
//
// This program analyzes text from various languages, and computes
// letter frequencies.  These letter frequencies serve as a "barcode"
// that potentially identify the language when written.  This approach,
// and assignment, is inspired by the students and professor of CS 141,
// Fall 2018, at the U. of Illinois, Chicago.  Kudos to Prof Reed.
//


//
// explode:
//
// Given a string s, explodes the string into a list of characters.
// Example: explode "apple" => ['a';'p';'p';'l';'e']
//
let explode s =
  [for c in s -> c]


//
// implode
//
// The opposite of explode --- given a list of characters, returns
// the list as a string.
//
let implode L =
  let sb = System.Text.StringBuilder()
  List.iter (fun c -> ignore (sb.Append (c:char))) L
  sb.ToString()


//
// FileInput:
//
// Inputs text from a file line by line, returning this as a list
// of strings.  Each line is converted to lower-case.
//
let FileInput filename = 
  [ for line in System.IO.File.ReadLines(filename) -> line.ToLower() ]


//
// UserInput:
//
// This function reads from the keyboard, line by line, until 
// # appears on a line by itself.  The lines are returned as
// a list of strings; each line is converted to lower-case.
//
// NOTE: if the first line of input is blank (i.e. the user 
// presses ENTER), then input is read from the file 'input.txt'.
// Helpful when testing.
//
let rec _UserInput input =
  let line = System.Console.ReadLine()
  match line with
  | "#" -> List.rev input
  |  _  -> _UserInput (line.ToLower() :: input)

let UserInput() =
  let firstLine = System.Console.ReadLine()
  match firstLine with
  | "" -> FileInput @"./input.txt"
  | _  -> _UserInput [firstLine.ToLower()]


let rec isEmpty S = 
  match S with
  | [] -> true
  | _  -> false
  

let rec ith i L = 
  match i with
  | 0 -> (List.head L)
  | _ -> ith (i-1) (List.tail L) 



let rec mysum L cmp x = 
  match L with
  | [ ] -> x
  | e:: rest -> if (e = cmp)then
                  mysum rest cmp (x+1)
                else
                  mysum rest cmp x 


let rec printFreqCounts L = 
  List.iter (fun (letter,count) -> printf "%A " count) L


let rec printFreqOrder L = 
  List.iter (fun (letter,count) -> printf "%c" letter ) L


let rec printFreqOrder1 L = 
  List.iter (fun (letter,count) -> printf "%A" letter ) L



//
// Processing the Training Files
//

let rec processfiles L L1 x =
  match L with
  | [] ->  L1
  | e::rest -> if (e=x)then
                 L1 @ (e,rest) :: processfiles rest L1 x
               else 
                 processfiles rest L1 x



let rec breakString L L1 x x1 s =
  match L with
  | [] ->  L1
  | e::rest -> if (x1=x)then
                 L1 
               else 
                 if (e=s)then
                   breakString rest L1 x (x+1) s
                 else
                  let L2 = explode e
                  let L1 = List.append L1 L2
                  breakString rest L1 x (x+1) s


let rec breakString1 L L1 x x1 =
  match L with
  | [] ->  L1
  | e::rest -> if (x1=x)then
                L1 
               else 
                let L2 = explode e
                let L1 = List.append L1 L2
                breakString1 rest L1 x (x+1) 





let rec processdata L L1 x y c1 = 
  match L with 
  | [] -> L1
  | e::rest -> if (y=x)then
                 L1
               else
                 let l = FileInput e
                 let str = ith 0 l
                 
                 let len = (List.length l) 
                 let L3 = breakString  l [] len 0 str
                 
                 let a =  mysum L3 'a' 0
                 let b =  mysum L3 'b' 0
                 let c =  mysum L3 'c' 0
                 let d =  mysum L3 'd' 0
                 let e =  mysum L3 'e' 0
                 let f =  mysum L3 'f' 0
                 let g =  mysum L3 'g' 0   
                 let h =  mysum L3 'h' 0
                 let i =  mysum L3 'i' 0
                 let j =  mysum L3 'j' 0
                 let k =  mysum L3 'k' 0
                 let l =  mysum L3 'l' 0
                 let m =  mysum L3 'm' 0
                 let n =  mysum L3 'n' 0
                 let o =  mysum L3 'o' 0
                 let p =  mysum L3 'p' 0
                 let q =  mysum L3 'q' 0
                 let r =  mysum L3 'r' 0
                 let s =  mysum L3 's' 0
                 let t =  mysum L3 't' 0
                 let u =  mysum L3 'u' 0
                 let v =  mysum L3 'v' 0
                 let w =  mysum L3 'w' 0   
                 let x1 =  mysum L3 'x' 0
                 let y =  mysum L3 'y' 0
                 let z =  mysum L3 'z' 0
                 let L5 = [("a",a);("b",b) ;("c",c);("d",d);("e",e);("f",f);("g",g);("h",h);("i",i);("j",j);("k",k);("l",l);("m",m);("n",n);("o",o);("p",p);("q",q);("r",r);("s",s);("t",t);("u",u);("v",v);("w",w);("x",x1);("y",y);("z",z);]
                 let L7 = [('a',a);('b',b) ;('c',c);('d',d);('e',e);('f',f);('g',g);('h',h);('i',i);('j',j);('k',k);('l',l);('m',m);('n',n);('o',o);('p',p);('q',q);('r',r);('s',s);('t',t);('u',u);('v',v);('w',w);('x',x1);('y',y);('z',z);]
                 
                 if (c1 = 0)then
                   printf  "%A" str 
                   printf  ": "
                   printFreqCounts L5
                   printfn ""
                   //printfn "Lang: %A" L5
                   let L4 = [(str,L3)]
                   // let L2 = processfiles l [] str
                   let L1 = List.append L1 L4
                   processdata rest L1 x (y+1) c1
                  else
                   let L6 = List.sortByDescending (fun (letter,count)-> count) L7
                   printf  "%A" str 
                   printf  ": "
                   printFreqOrder L6
                   printfn ""
                 //  printfn "Lang: %A" L6
                   let L4 = [(str,L3)]
                   // let L2 = processfiles l [] str
                   let L1 = List.append L1 L4
                   processdata rest L1 x (y+1) c1





let rec processdata1 L L1 x y c1 co L6 = 
  match L with 
  | [] -> L6
  | e::rest -> if (y=x)then
                 L6
               else
                if(co=0)then 
                 let len = (List.length L) 
                 let L3 = breakString1  L [] len 0 
                 
                 let a =  mysum L3 'a' 0
                 let b =  mysum L3 'b' 0
                 let c =  mysum L3 'c' 0
                 let d =  mysum L3 'd' 0
                 let e =  mysum L3 'e' 0
                 let f =  mysum L3 'f' 0
                 let g =  mysum L3 'g' 0   
                 let h =  mysum L3 'h' 0
                 let i =  mysum L3 'i' 0
                 let j =  mysum L3 'j' 0
                 let k =  mysum L3 'k' 0
                 let l =  mysum L3 'l' 0
                 let m =  mysum L3 'm' 0
                 let n =  mysum L3 'n' 0
                 let o =  mysum L3 'o' 0
                 let p =  mysum L3 'p' 0
                 let q =  mysum L3 'q' 0
                 let r =  mysum L3 'r' 0
                 let s =  mysum L3 's' 0
                 let t =  mysum L3 't' 0
                 let u =  mysum L3 'u' 0
                 let v =  mysum L3 'v' 0
                 let w =  mysum L3 'w' 0   
                 let x1 =  mysum L3 'x' 0
                 let y =  mysum L3 'y' 0
                 let z =  mysum L3 'z' 0
                 let L5 = [("a",a);("b",b) ;("c",c);("d",d);("e",e);("f",f);("g",g);("h",h);("i",i);("j",j);("k",k);("l",l);("m",m);("n",n);("o",o);("p",p);("q",q);("r",r);("s",s);("t",t);("u",u);("v",v);("w",w);("x",x1);("y",y);("z",z);]
                 let L7 = [('a',a);('b',b) ;('c',c);('d',d);('e',e);('f',f);('g',g);('h',h);('i',i);('j',j);('k',k);('l',l);('m',m);('n',n);('o',o);('p',p);('q',q);('r',r);('s',s);('t',t);('u',u);('v',v);('w',w);('x',x1);('y',y);('z',z);]
                 
                 if (c1 = 0)then
                   printf  "input" 
                   printf  ": "
                   printFreqCounts L5
                   printfn ""
                   //printfn "Lang: %A" L5
                  // let L4 = [(str,L3)]
                   // let L2 = processfiles l [] str
                   let L1 = List.append L1 L3
                   processdata1 rest L1 x (y+1) c1 1 L6
                  else
                   let L6 = List.sortByDescending (fun (letter,count)-> count) L7
                   
                   printf  "input"
                   printf  ": "
                   printFreqOrder L6
                   printfn ""
                  // printfn "Lang: %A" L6
                  // let L4 = [(str,L3)]
                   // let L2 = processfiles l [] str
                   let L1 = List.append L1 L3
                   processdata1 rest L1 x (y+1) c1 1 L6
                else
                 L6


let rec getlist L =
  match L with
  | [] -> []
  | (letter,count)::rest -> (letter) :: getlist rest



let rec getdifference L L1 x thresh d =
   if(x=26)then
    d
   else 
    let res =  (abs(((List.findIndex(fun elem -> elem = (ith x L))) L)))
    let res1 = (abs(((List.findIndex(fun elem -> elem = (ith x L))) L1)))
    let diff = abs(res - res1)
    if(diff > thresh)then
      //printfn "x: %A" res 
      //printfn "x1: %A" res1 
      //printfn "diff: %A" diff
      getdifference L L1 (x+1) thresh (d+diff)
    else 
      getdifference L L1 (x+1) thresh d

let rec processdiff L L1 x y c1 Ln th Ld = 
  match L with 
  | [] -> Ld
  | e::rest -> if (y=x)then
                 Ld
               else
                 let l = FileInput e
                 let str = ith 0 l
                 
                 let len = (List.length l) 
                 let L3 = breakString  l [] len 0 str
                 
                 let a =  mysum L3 'a' 0
                 let b =  mysum L3 'b' 0
                 let c =  mysum L3 'c' 0
                 let d =  mysum L3 'd' 0
                 let e =  mysum L3 'e' 0
                 let f =  mysum L3 'f' 0
                 let g =  mysum L3 'g' 0   
                 let h =  mysum L3 'h' 0
                 let i =  mysum L3 'i' 0
                 let j =  mysum L3 'j' 0
                 let k =  mysum L3 'k' 0
                 let l =  mysum L3 'l' 0
                 let m =  mysum L3 'm' 0
                 let n =  mysum L3 'n' 0
                 let o =  mysum L3 'o' 0
                 let p =  mysum L3 'p' 0
                 let q =  mysum L3 'q' 0
                 let r =  mysum L3 'r' 0
                 let s =  mysum L3 's' 0
                 let t =  mysum L3 't' 0
                 let u =  mysum L3 'u' 0
                 let v =  mysum L3 'v' 0
                 let w =  mysum L3 'w' 0   
                 let x1 =  mysum L3 'x' 0
                 let y =  mysum L3 'y' 0
                 let z =  mysum L3 'z' 0
                 let L5 = [("a",a);("b",b) ;("c",c);("d",d);("e",e);("f",f);("g",g);("h",h);("i",i);("j",j);("k",k);("l",l);("m",m);("n",n);("o",o);("p",p);("q",q);("r",r);("s",s);("t",t);("u",u);("v",v);("w",w);("x",x1);("y",y);("z",z);]
                 let L7 = [('a',a);('b',b) ;('c',c);('d',d);('e',e);('f',f);('g',g);('h',h);('i',i);('j',j);('k',k);('l',l);('m',m);('n',n);('o',o);('p',p);('q',q);('r',r);('s',s);('t',t);('u',u);('v',v);('w',w);('x',x1);('y',y);('z',z);]
                 
                 if (c1 = 0)then
                  let L4 = [(str,L3)]
                  // let L2 = processfiles l [] str
                  let L1 = List.append L1 L4
                  processdiff rest L1 x (y+1) c1 Ln th Ld
                 else
                   let L6 = List.sortByDescending (fun (letter,count)-> count) L7
                   let l1 = getlist L6
                   let l2 = getlist Ln
                   //let res = (abs(((List.findIndex(fun elem -> e = elem)) l1) - ((List.findIndex(fun elem -> e = elem)) l2)))
                   let res = getdifference l1 l2 0 th 0
                   //printf "diff: %A" res 
                   //printf  "res1: %A" l2
                   let L9 = [(str,res)]
                   let Ld = List.append Ld L9
                   // printf  "diffs: %A" L9 
                   //printf  ": "
                   // printFreqCounts L9
                   //printfn ""
                   //  printfn "Lang: %A" L6
                   let L4 = [(str,L3)]
                   // let L2 = processfiles l [] str
                   let L1 = List.append L1 L4
                   processdiff rest L1 x (y+1) c1 Ln th Ld







// *********************************************************************** //
//
// Main:
//
[<EntryPoint>]
let main argv =
  printfn "** Training... **"
  printfn ""
  //
  let files = [ for filename in System.IO.Directory.GetFiles(@"./training") -> filename]
  let files = List.sort files
  
  let length = files.Length
  
 // printfn "Training files: %A" files
  //let l = FileInput (ith 0 files)
  //let str = ith 0 l
//  let R = processdata files [] length 0
  
  
 // printfn "Training files: %A" R
  //
  printfn "** Letter Frequency Counts (A->Z) **"
  let R = processdata files [] length 0 0
  printfn ""
 
  //
  printfn "** Letter Frequency Order (High->Low) **"
  let R1 = processdata files [] length 0 1
  printfn ""
  //
  // Here we get text from the user, analyze, and guess the language:
  //
  printfn "Please enter text, followed by # (default = 'input.txt')> "
  let text = UserInput()
  printfn ""
 // printfn "** Letter Frequency Counts (A->Z) **"
  let R2 = processdata1 text [] length 0 0 0 []
 // printfn ""
  //
 // printfn "** Letter Frequency Order (High->Low) **"
  let R3 = processdata1 text [] length 0 1 0 []
  printfn ""
  
  
  
  
  
  //
  printf "Enter difference threshold (default = 4)> "
  let s = System.Console.ReadLine()
  let threshold = if s = "" then 4 else int(s)
  printfn ""
  // printfn "Training files: %A" R3
  let R4 = processdiff files [] length 0 1 R3 threshold []
  
  let R5 = List.sortBy(fun (letter,count)-> count) R4
  printf  "diffs: %A" R5
   
  printfn ""
  printfn ""
  
  //
  
  let min = [List.min R5]
  
  //let prediction = min
  printf "** Input language: " 
  printFreqOrder1 min
  printfn ""
  //
  0
