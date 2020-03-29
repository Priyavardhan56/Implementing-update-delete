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
              var Name = $("#Name").val();
              var AppointmentType = $("input[name='AppointmentType']:checked").val();
            var Address = $("#Address").val();
            var Phone = $("#Phone").val();
              var Problem = $("#Problem").val();
              var Payment = $("#Payment").val();
           
         

            var h = "<tr>";
              h += "<td>" + Name + "</td>";
              h += "<td>" + AppointmentType + "</td>";
            h += "<td>" + Address + "</td>";
            h += "<td>" + Phone + "</td>";
            h += "<td>" + Problem + "</td>";
              h += "<td>" + Payment + "</td>";
             
          
            h += "</tr>";
            $("#tblData tr:last").after(h);
          }
        },
        false
      );
    },
    false
  );
})();
