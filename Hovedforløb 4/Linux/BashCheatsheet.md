# Bash Cheatsheet

## Variables

```sh
my_variable='Hello, World!'
```

* **$0** - The name of the Bash script.
* **$1 - $9** - The first 9 arguments to the Bash script. (As mentioned above.)
* **$#** - How many arguments were passed to the Bash script.
* **$@** - All the arguments supplied to the Bash script.
* **$?** - The exit status of the most recently run process.
* **$$** - The process ID of the current script.
* **$USER** - The username of the user running the script.
* **$HOSTNAME** - The hostname of the machine the script is running on.
* **$SECONDS** - The number of seconds since the script was started.
* **$RANDOM** - Returns a different random number each time is it referred to.
* **$LINENO** - Returns the current line number in the Bash script.

## Simple Calculation

```sh
let "my_variable = 1 + 1"
my_variable=$( expr 1 + 1 )
my_variable=$(( 1 + 1 ))
```

## String Modification

* **Length** - ${#my_variable}

## Conditions

### if, else if, else

```sh
if [condition]
then
    #do code
elif [other condition] || [some other condition]
then
    #do something else
else
    #do something completely else
fi
```

### switch/case

```sh
case my_variable in
    1)
        #my_variable = 1
        ;;
    [2-3]*)
        #my_variable starts with 2 | 3
        ;;
    [5-9])
        #my_variable = 5 | 6 | 7 | 8 | 9
        ;;
    hello)
        #my_variable = hello
        ;;
    *)
        #default case
        ;;
esac
```

## Loops

### While Loops

```sh
while [condition]
do
    #something
done
```

### Until Loops (do-while)

```sh
until [condition]
do
    #something
done
```

### For Loops

```sh
sentence='This is a list'
for word in $sentence 
do
    #something
done

for i in {0..9}
do
    #something
    if [i == 8]
    then
        break
    elif [i == 5]
    then
        continue
    fi
done
```

## Select

```sh
items='choice1 choice2 choice3'
PS3='Select option: '
echo

select item in $items
do
    #item must be numeric
    if [ $item -lt 0 ]
    then
        continue
    fi
    
    echo You chose $item!
    break
done
```
