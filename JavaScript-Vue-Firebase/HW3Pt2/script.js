const el = document.getElementById("goBtn");

  el.addEventListener("click", (ev) => {
    const inp = document.getElementById("numInput");
    const len = Number(inp.value); // convert string to number


    const parent = document.getElementById("table1");
    let victims = document.querySelectorAll(".victim");
    for (x of victims) {
      parent.removeChild(x);
    }
fetch(`https://dawn2k-random-german-profiles-and-names-generator-v1.p.rapidapi.com/?count=${len}&gender=b&maxage=40&minage=30&cc=all&email=gmail.com%2Cyahoo.com&pwlen=12&ip=a&phone=l%2Ct%2Co&uuid=false&lic=false&color=false&seed=helloworld&images=false&format=json`, {
	"method": "GET",
	"headers": {
		"x-rapidapi-host": "dawn2k-random-german-profiles-and-names-generator-v1.p.rapidapi.com",
		"x-rapidapi-key": "a4e4bfd323msh36a0a2bd08bf70bp1abde8jsnb2eef0cfaf57"
	}
})
.then(function(httpResponse) {
    let dataInJson = httpResponse.json();
    return dataInJson; 
  })
  .then((userData) => {
    let id = document.getElementById("table1");
    let tr1 = document.createElement("tr");
    id.appendChild(tr1);
    let th1 = document.createElement("th");
    th1.textContent = "Name";
    let th2 = document.createElement("th");
    th2.textContent = "Email";
    let th3 = document.createElement("th");
    th3.textContent = "Username";
    let th4 = document.createElement("th");
    th4.textContent = "Password";
    tr1.classList.add("victim");

    tr1.appendChild(th1);
    tr1.appendChild(th2);
    tr1.appendChild(th3);
    tr1.appendChild(th4);
    let i = 0;
    for (let u of userData) {
        let x = userData[0].firstname;
        let tr2 = document.createElement("tr");
        tr2.classList.add("victim");

        id.appendChild(tr2);

        let tdName = document.createElement("td");
        tdName.textContent = userData[i].firstname + " " + userData[i].lastname;
        tdName.classList.add("tableRow1");
        tr2.appendChild(tdName);
        
        let tdEmail = document.createElement("td");
        tdEmail.textContent = userData[i].email;
        tdEmail.classList.add("tableRow2");
        tr2.appendChild(tdEmail);

        let tdUserName = document.createElement("td");
        tdUserName.textContent = userData[i].username;
        tdUserName.classList.add("tableRow3");
        tr2.appendChild(tdUserName);
        
        let tdPassword = document.createElement("td");
        tdPassword.classList.add("tableRow4");
        tdPassword.textContent = userData[i].password;        
        tr2.appendChild(tdPassword);

        i++;
    }
  })
.catch(err => {
	console.log(err);
});
});