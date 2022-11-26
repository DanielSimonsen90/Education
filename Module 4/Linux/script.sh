#!/bin/bash

function on_calc {
    local result=$(( $1 $2 $3 ))
    echo Your result is: $result
    return 0
}

function on_help {
    PS3='Select option: '
    echo

    select chosen in $options
    do
        echo Choice registered as $chosen
        ./script.sh $chosen
        break
    done

    return 0
}


function run_clear {
    # CLEAR is false
    if [$1 == 0]
    then 
        return 0
    fi

    clear
    return 0
}


options='clear calc help'
CLEAR=0

case $1 in
    clear)
        CLEAR=1
        ;;
    calc)
        on_calc $2 $3 $4
        ;;
    help)
        on_help
        ;;
    *)
        echo "Unknown argument! "$1
        ;;
esac

run_clear $CLEAR