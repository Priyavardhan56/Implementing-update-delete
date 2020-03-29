(function() {
  "use strict";
  window.addEventListener(
    "load",
    function() {
      var form = document.getElementById("myform");
      form.addEventListener(
        "submit",
        function(event) {
          if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
          }
          form.classList.add("was-validated");
          if (form.checkValidity() === true) {
            event.preventDefault();
            event.stopPropagation();
            var Symptoms = $("#tokenfield").val();
            var Symptom = $("#tokenfield2").val();
            var h = "<tr>";
            h += "<td>" + Symptoms + "</td>";
            h += "<td>" + Symptom + "</td>";
         
            h += "</tr>";
            $("#tbl tr:last").after(h);
          }////////
        },
        false
      );
    },
    false
  );
})();
