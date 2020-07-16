# Smileyscript
A Brainfuck interpreter that can read your code in smileys :)

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
