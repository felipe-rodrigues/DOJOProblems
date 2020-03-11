// Given a sorted list of integers, square the elements and give the output in sorted order.
// Note: The integers can be 0 or negative.
// Example 1
// Input
// nums = [-9, -2, 0, 2, 3]
// Output
// [0, 4, 4, 9, 81]
// Example 2
// Input
// nums = [1, 2, 3, 4, 5]
// Output
// [1, 4, 9, 16, 25]


var input = [-9, -2, 0, 2, 3];
console.log('Given the input' , input );
console.log('We have the result' , solution1(input));


function solution1 (array) {
    var result = [];
    array.forEach(element => {
        result.push(Math.pow(element,2));
    });
    return result.sort((a,b) => a - b);
}

function solution2 (array) {
    var result = [];
}