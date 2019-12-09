// Verify part00
(() => {
  // Part 0
  let target, top;
  target = document.querySelector("#part00 b");
  top = document.getElementById("part00");
  if (target) {
    top.classList.add("OK");
  } else {
    top.classList.add("FAIL");
  }

  // Part 1
  target = document.querySelectorAll("#part01 ol li");
  top = document.getElementById("part01");
  top.classList.add(target && target.length == atoms.length ? "OK" : "FAI");

  // Part 2

  top = document.getElementById("part02");
  const dataAvail =
    typeof myDomesticTravel.destination === "string" &&
    typeof myDomesticTravel.dateOfVisit === "string" &&
    typeof myDomesticTravel.isAbroad === "boolean" &&
    typeof myInternationalTravel.destination === "string" &&
    typeof myInternationalTravel.dateOfVisit === "string" &&
    typeof myInternationalTravel.isAbroad === "boolean";
  if (dataAvail) {
    top.classList.add("OK");
    target = document.querySelectorAll("#part02 > p");
    if (target && target.length >= 2) {
      let klasOk = false;
      if (target[0].textContent.indexOf(myDomesticTravel.destination)) {
        klasOk =
          target[0].classList.contains("domestic") &&
          target[1].classList.contains("international");
      } else {
        klasOk =
          target[1].classList.contains("domestic") &&
          target[0].classList.contains("international");
      }
      top.classList.add(klasOk ? "OK" : "FAIL");
    } else top.classList.add("FAIL");
  } else top.classList.add("FAIL");

  // Part 3
  target = document.querySelectorAll("#part03 ol li");
  top = document.getElementById("part03");
  let textOk = true;
  for (t of target) {
    if (t.textContent.indexOf("weight") < 0) {
      textOk = false;
      break;
    }
  }
  let styleOk = false;
  heavyList = document.querySelectorAll("#part03 ol li.heavy");
  heavyAtoms = atomObjects.filter((a) => a.weight > 150);
  styleOk = heavyList.length == heavyAtoms.length;
  top.classList.add(
    target && target.length == atomObjects.length && textOk && styleOk
      ? "OK"
      : "FAIL"
  );

  // Part 4
  top = document.getElementById("part04");
  target = top.querySelectorAll("table tr");
  let heavyRows = top.querySelectorAll("table tr.heavy");
  let headerRow = top.querySelector("table tr:first-child");
  let headerOK = false;
  headerOK =
    headerRow &&
    headerRow.children.length == 2 &&
    headerRow.children[0].firstChild.nodeValue.toLowerCase() == "atom" &&
    headerRow.children[1].firstChild.nodeValue.toLowerCase() == "weight";
  let tabRowsOK =
    headerOK &&
    target.length === atomObjects.length + 1 &&
    heavyRows.length === heavyAtoms.length;
  top.classList.add(tabRowsOK ? "OK" : "FAIL");
})();
