//if the input is "DBCABA" the output must be = "B"


var input = "DBCABAD";
console.log('Given the input' , input );
console.log('We have the result' , solution1(input));

function solution1(input = '') {

    var arrayResult = {};
    var biggesCharacter = input.charAt(0);
   
    arrayResult[biggesCharacter] =1;

    for ( i =1; i< input.length ; i++) {
        var current = input.charAt(i);
        if(!arrayResult[current]){
            arrayResult[current] = 1;
        } else {
            arrayResult[current]++;
        }
        if( biggesCharacter != current && arrayResult[current] > arrayResult[biggesCharacter]) {
            biggesCharacter = current;
        }  
    }

    return arrayResult[biggesCharacter] > 1 ? biggesCharacter : null;
    
}