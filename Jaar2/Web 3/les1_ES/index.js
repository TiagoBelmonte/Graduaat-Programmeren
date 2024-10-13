// ES5 Syntax

const sp = "----------------------";

// forEach()
const arrCourses = ["Web1", "Web2", "Web3", "Mobile"];

//Als je een break moet gebruiken -> Manuele for loop, geen forEach
for (let idx = 0; idx < arrCourses.length; idx++) {
  if (idx == 2) {
    break;
  }
  const element = arrCourses[idx];
  console.log(element);
}
console.log(sp);

arrCourses.forEach((e) => console.log(e));

console.log(sp);

//Map Methode
const arrNumbers = [1, 2, 3, 4, 5];
const newArr = arrNumbers.map((x) => x * 5);
console.log(arrNumbers);
console.log(newArr);

const numbersStrArr = arrNumbers.map((x) => x.toString());
console.log(numbersStrArr);

console.log(sp);

//REDUCE methode
const sumOfArr = arrNumbers.reduce((acc, val) => {
  return acc + val;
});

console.log("sum of array:", sumOfArr);

// Initiële waarde aan reduce
[].reduce((acc, val) => acc + val, 0);

console.log(sp);

const sumUnEven = arrNumbers.reduce((acc, val) => {
  if (val % 2 != 0) {
    return acc + val;
  } else {
    return acc;
  }
}, 0);
console.log(sumUnEven);

console.log(sp);

// FILTER
const filteredCourses = arrCourses.filter((e) => e !== "Web3");
console.log(filteredCourses);

// SOME Methode

arrCourses.some((e) => {
  return e === "Mobile";
});

//Every methode
const isEveryMobile = arrCourses.every((e) => {
  return e === "Mobile";
});

console.log(sp);

const student = {
  firstName: "Georges",
  lastName: "Hautekier",
  city: "gent",
};

student.Street = "huisjesstraat 32";

console.log(student);

console.log(sp);

const sum = (...arr) => {
  return arr.reduce((acc, val) => acc + val, 0);
};

sum();
sum(1);
sum(1, 2);
sum(1, 2, 3);

const arr1 = [1, 2, 12];
const arr2 = [3, 4, 5];

const arr3 = arr1.concat(arr2);
const studentCopy = { ...student };

const a = arr1[1];
const b = arr1[2];
const [first, second, third] = arr1;

console.log(third);

console.log(sp);
const { lastName: stduentLastName, address: city } = student;

const newFunction = (cb) => {
  cb();
};

newFunction(() => {
  console.log("test");
});

newFunction((a, b) => {
  return a + b;
});

const ownMap = (arr, cb) => {
  let tempArr = [];
  arr.forEach((e) => {
    tempArr.push(cb(e));
  });
  return arr.map(cb);
};

const result1 = ownMap(arr1, (e) => e * 5);
console.log(result1);

const result2 = ownMap(arr1, (e) => e + 15);
console.log(result2);

//TIMERS -> CALLBACK HELL
setTimeout(() => {
  console.log("bericht na 5 seconden");
}, 5000);
console.log("test na timeout");
//-> voert uit voor de timeout aangezien javascript volgende lijnen code al uitvoert
//-> ongeacht als timer op 0 seconden is gezet.
console.log(sp);

//PROMISES
const myPromise = new Promise((resolve, reject) => {
  // Code die een tijdje kan duren
  // Connectie met een databank - file system - requeste
  setTimeout(() => {
    const result = false;
    if (result) {
      resolve();
    } else {
      reject();
    }
  }, 1000);
});

myPromise
  .then(() => {
    console.log("promise was succesvol");
  })
  .catch(() => {
    console.log("Promise was niet succesvol!");
  });
