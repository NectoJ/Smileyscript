# Smileyscript
A Brainfuck interpreter that can read your code in smileys :)

## "Hello World" in SmileyScript
```
:) :) :) :) :) :) :) :) :) :) :[ :> :) :) :) :) :) :) :) :>
:) :) :) :) :) :) :) :) :) :) :> :) :) :) :> :) :< :< :< :<
:( :] :> :) :) :O :> :) :O :) :) :) :) :) :) :) :O :O :) :)
:) :O :> :) :) :O :< :< :) :) :) :) :) :) :) :) :) :) :) :)
:) :) :) :O :> :O :) :) :) :O :( :( :( :( :( :( :O :( :( :(
:( :( :( :( :( :O :> :) :O :> :O :> :) :) :) :) :) :) :) :)
:) :) :) :) :) :) :O
```

## How does it work?

| Smileys | Brainfuck Equivalent              |
|---------|-----------------------------------|
| :)      | + (Increment)                     |
| :(      | - (Decrement)                     |
| :[      | [ (Begin Loop)                    |
| :]      | ] (End Loop)                      |
| :<      | < (Move the pointer to the left)  |
| :>      | > (Move the pointer to the right) |
| :I      | , (Receive a single input)        |
| :O      | . (Return a single output)        |

## How to run?

```
SmileyScript.exe "Examples/hello.txt"
```

## Please note!
This repository is extremely underdeveloped and may have bugs that are yet to be found.
