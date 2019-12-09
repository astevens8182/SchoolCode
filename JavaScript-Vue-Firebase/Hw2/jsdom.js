// Sample Code for #part0
let zero = document.querySelector("#part00");
let hello = document.createTextNode("Hello world!");
// zero.appendChild(hello);
/*--- begin answer part00 ---*/
let myname = "Alex Stevens"

/*--- end answer part00 ---*/
if (typeof myname !== "undefined") {
  let textBefore = document.createTextNode("My name is ");
  zero.appendChild(textBefore);
  let boldNode = document.createElement("b");
  let name = document.createTextNode(myname);
  zero.appendChild(boldNode);
  boldNode.appendChild(name);
  let textAfter = document.createTextNode(". This work is solely mine! ");
  zero.appendChild(textAfter);

  zero.appendChild(
    document.createTextNode(
      "I understand that " +
        "copying someone else's code and claiming to be my own work " +
        "or sharing my code with someone else is a "
    )
  );
  let honesty = document.createElement("b");
  honesty.appendChild(document.createTextNode("violation"));
  zero.appendChild(honesty);
  zero.appendChild(document.createTextNode(" of academic honesty."));
}

// Code for part 1
let atoms = [
  "Aluminum",
  "Barium",
  "Carbon",
  "Dubnium",
  "Erbium",
  "Fluor",
  "Gallium",
  "Hydrogen",
  "Helium",
  "Iron",
  "Krypton",
  "Lithium",
  "Magnesium",
  "Nitrogen",
  "Oxygen",
  "Palladium",
  "Radon",
  "Silicon",
  "Titanium",
  "Uranium",
  "Vanadium",
  "Xenon",
  "Zinc"
];

let N = atoms.length;
for (let k = 0; k < 50; k++) {
  const pos1 = Math.floor(Math.random() * N);
  const pos2 = Math.floor(Math.random() * N);
  let tmp = atoms[pos1];
  atoms[pos1] = atoms[pos2];
  atoms[pos2] = tmp;
}

/*--- begin answer part01 ---*/
let id = document.getElementById("part01");
let ul = document.createElement("ol");
id.appendChild(ul);
for (let i = 0; i < atoms.length; i++) {
let atom = atoms[i];

let listItem = document.createElement("li");
listItem.textContent = atom;
ul.appendChild(listItem);
}

/*--- end answer part01 ---*/

// Code for part 2
// Don't rename the following two variables!
/*--- begin answer part02 ---*/
const myDomesticTravel = {destination : "Utah", dateOfVisit : "June 2019", isAbroad : false};
const myInternationalTravel = {destination : "Mexico", dateOfVisit : "May 2019", isAbroad : true};

let id2 = document.getElementById("part02");
let p2 = document.createElement("p");
id2.appendChild(p2);
let p3 = document.createElement("p");
id2.appendChild(p3);
p2.classList.add("domestic");
p3.classList.add("international");
let phrase1 = "I had fun this ";
let phrase2 = " spending time with my family in "
let phrase3 = "My mom is so generous to pay for my air ticket to "
p2.textContent = phrase1 + myDomesticTravel.dateOfVisit + phrase2 + myDomesticTravel.destination + ". " + phrase3 + myDomesticTravel.destination + " in " + myDomesticTravel.dateOfVisit;
p3.textContent =  phrase1 + myInternationalTravel.dateOfVisit + phrase2 + myInternationalTravel.destination + ". " + phrase3 + myInternationalTravel.destination + " in " + myInternationalTravel.dateOfVisit;

/*--- end answer part02 ---*/

// Code for part 3
let atomObjects = [
  { name: "Aluminum", weight: 26.982 },
  { name: "Barium", weight: 137.33 },
  { name: "Carbon", weight: 12.011 },
  { name: "Dubnium", weight: 268 },
  { name: "Erbium", weight: 167.26 },
  { name: "Fluor", weight: 18.988 },
  { name: "Gallium", weight: 69.723 },
  { name: "Hydrogen", weight: 1.008 },
  { name: "Helium", weight: 4.0026 },
  { name: "Iron", weight: 55.845 },
  { name: "Krypton", weight: 83.798 },
  { name: "Lithium", weight: 6.94 },
  { name: "Magnesium", weight: 24.305 },
  { name: "Nitrogen", weight: 14.007 },
  { name: "Oxygen", weight: 15.999 },
  { name: "Palladium", weight: 106.42 },
  { name: "Radon", weight: 222 },
  { name: "Silicon", weight: 28.085 },
  { name: "Titanium", weight: 47.867 },
  { name: "Uranium", weight: 238.03 },
  { name: "Vanadium", weight: 50.942 },
  { name: "Xenon", weight: 131.29 },
  { name: "Zinc", weight: 65.38 }
];
N = atomObjects.length;
for (let k = 0; k < 50; k++) {
  const pos1 = Math.floor(Math.random() * N);
  const pos2 = Math.floor(Math.random() * N);
  let tmp = atomObjects[pos1];
  atomObjects[pos1] = atomObjects[pos2];
  atomObjects[pos2] = tmp;
}

/*--- begin answer part03 ---*/
let id3 = document.getElementById("part03");
let ul1 = document.createElement("ol");
id3.appendChild(ul1);

for (let i = 0; i < atomObjects.length; i++) {
  let atomObject = atomObjects[i];
  
  let li1 = document.createElement("li");
  if(atomObject.weight > 150){
    li1.classList.add("heavy");
  }
  else{
    li1.classList.add("light");
  }
  li1.textContent = atomObject.name +" (weight: " + atomObject.weight.toFixed(1) + ")";
  ul1.appendChild(li1);
  }
/*--- end answer part03 ---*/

// Code for part 4
/*--- begin answer part04 ---*/
let id4 = document.getElementById("part04");
let table = document.createElement("table");
id4.appendChild(table);
let tr1 = document.createElement("tr");
table.appendChild(tr1);
let th1 = document.createElement("th");
th1.textContent = "Atom";
let th2 = document.createElement("th");
th2.textContent = "Weight";
tr1.appendChild(th1);
tr1.appendChild(th2);

for (let i = 0; i < atomObjects.length; i++) {
  let atomObject = atomObjects[i];
  let tr2 = document.createElement("tr");
  table.appendChild(tr2);
  let tdName = document.createElement("td");
  tdName.textContent = atomObject.name;
  tr2.appendChild(tdName);

  let tdWeight = document.createElement("td");
  tdWeight.textContent = atomObject.weight;
  tr2.appendChild(tdWeight);

  if(atomObject.weight > 150){
    tr2.classList.add("heavy");
  }
  else{
    tr2.classList.add("light");
  }

  }
  /*--- end answer part04 ---*/

// Code for part 4
/*--- begin answer part04 ---*/
/*--- end answer part04 ---*/

// Code for part 5 (Extra credit)
/*--- begin answer part05 ---*/
/*--- end answer part05 ---*/
