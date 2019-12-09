
  const el = document.getElementById("goBtn");
  let div1  = document .getElementById("div1");

  const convertResponseToJson = function(r) {
    return r.json();
  }
  
  el.addEventListener("click", (ev) => {
    const inp = document.getElementById("numInput");
    const len = Number(inp.value); // convert string to number
    const parent = document.getElementById("table1");
    let victims = document.querySelectorAll(".victim");
    for (x of victims) {
      parent.removeChild(x);
    }
    
fetch(`https://randomuser.me/api?results=${len}`)
  .then((r) => r.json()) // convert the response 'r' to a JSON object
  .then((d) => {
    let id  = document .getElementById("table1");
    let tr1 = document.createElement("tr");
    id.appendChild(tr1);
    let th1 = document.createElement("th");
    th1.textContent = "Name";
    let th2 = document.createElement("th");
    th2.textContent = "Cell Phone";
    let th3 = document.createElement("th");
    th3.textContent = "Date of Birth";
    let th4 = document.createElement("th");
    th4.textContent = "Thumbnail";
    tr1.classList.add("victim");

    tr1.appendChild(th1);
    tr1.appendChild(th2);
    tr1.appendChild(th3);
    tr1.appendChild(th4);
  
    for (let u of d.results){
        let tr2 = document.createElement("tr");
        tr2.classList.add("victim");

        id.appendChild(tr2);

        let tdName = document.createElement("td");
        tdName.textContent = u.name.first + " " + u.name.last;
        tdName.classList.add("tableRow1");
        tr2.appendChild(tdName);

        let tdCellPhone = document.createElement("td");
        tdCellPhone.textContent = u.cell;
        tdCellPhone.classList.add("tableRow2");
        tr2.appendChild(tdCellPhone);

        let tdDob = document.createElement("td");
        tdDob.textContent = u.dob.date;
        tdDob.classList.add("tableRow3");
        tr2.appendChild(tdDob);

        let tdImg = document.createElement("td");
        tdImg.classList.add("tableRow4");
        let img1 = document.createElement("img");
        img1.setAttribute("src", u.picture.thumbnail);
        tdImg.appendChild(img1);
        tr2.appendChild(tdImg);


    }
  });

});


