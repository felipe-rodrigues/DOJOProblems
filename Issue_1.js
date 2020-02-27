// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
// For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.



var execution = solution2([1,15,10,7], 17);
console.log('Execution' , execution);

//version 1
function KisFoundOnListBy2NumbersSum(array , k) {

    if (array.length < 2) return false;
    
    for( x =0 ; x< array.length; x++) {
        val = array[x];
        for(i = x+1;  i < array.length ; i++) {
            val2 = array[i];
            if(val + val2 == k){
                console.log(`yes cas ${val} + ${val2} is equal to ${k}`);
                return true;
            }
        }
    }

    return false;
}

function solution2(array, k){

    var valueINeed = [];
    var x = array[0];

    for(i = 1; i < array.length; i++) {
        var currentValue = array[i];

        if(valueINeed.find( x => x == currentValue)){
            return true;
        } else {
            valueINeed.push(k - currentValue);
        }
    }

    return false;
}

