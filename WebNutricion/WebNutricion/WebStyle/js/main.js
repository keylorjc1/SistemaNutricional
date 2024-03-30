(function ($) {

    "use strict";

    // Setup the calendar with the current date
    function check_events(day, month, year) {
        var events = [];
        for (var i = 0; i < event_data["events"].length; i++) {
            var event = event_data["events"][i];
            if (event["day"] === day &&
                event["month"] === month &&
                event["year"] === year) {
                events.push(event);
            }
        }
        return events;
    }
    $(document).ready(function () {
        var date = new Date();
        var today = date.getDate();
        // Set click handlers for DOM elements
        $(".right-button").click({ date: date }, next_year);
        $(".left-button").click({ date: date }, prev_year);
        $(".month").click({ date: date }, month_click);
        $("#add-button").click({ date: date }, new_event);
        // Set current month as active
        $(".months-row").children().eq(date.getMonth()).addClass("active-month");
        init_calendar(date);
        var events = check_events(today, date.getMonth() + 1, date.getFullYear());
        show_events(events, months[date.getMonth()], today);
    });

    $("#today-button").click(function () {
        var date = new Date(); // Get the current date
        init_calendar(date); // Initialize the calendar with the current date

        // Move the month view to the current month
        $(".active-month").removeClass("active-month");
        $(".month").eq(date.getMonth()).addClass("active-month");

        // Select the current day
        $(".active-date").removeClass("active-date");
        $(".table-date").eq(date.getDate() - 1).addClass("active-date");
    });

    // Initialize the calendar by appending the HTML dates
    function init_calendar(date) {
        $(".tbody").empty();
        $(".events-container").empty();
        var calendar_days = $(".tbody");
        var month = date.getMonth();
        var year = date.getFullYear();
        var day_count = days_in_month(month, year);
        var row = $("<tr class='table-row'></tr>");
        var today = date.getDate();
        // Set date to 1 to find the first day of the month
        date.setDate(1);
        var first_day = date.getDay();
        // 35+firstDay is the number of date elements to be added to the dates table
        // 35 is from (7 days in a week) * (up to 5 rows of dates in a month)
        for (var i = 0; i < 35 + first_day; i++) {
            // Since some of the elements will be blank, 
            // need to calculate actual date from index
            var day = i - first_day + 1;
            // If it is a sunday, make a new row
            if (i % 7 === 0) {
                calendar_days.append(row);
                row = $("<tr class='table-row'></tr>");
            }
            // if current index isn't a day in this month, make it blank
            if (i < first_day || day > day_count) {
                var curr_date = $("<td class='table-date nil'>" + "</td>");
                row.append(curr_date);
            }
            else {
                var curr_date = $("<td class='table-date'>" + day + "</td>");
                var events = check_events(day, month + 1, year);
                if (today === day && $(".active-date").length === 0) {
                    curr_date.addClass("active-date");
                    show_events(events, months[month], day);
                }
                // If this date has any events, style it with .event-date
                if (events.length !== 0) {
                    curr_date.addClass("event-date");
                }
                // Set onClick handler for clicking a date
                curr_date.click({ events: events, month: months[month], day: day }, date_click);
                // Check if the day is a Sunday
                var check_date = new Date(year, month, day);
                if (check_date.getDay() === 0) { // 0 is Sunday
                    curr_date.off("click"); // Remove click handler
                    curr_date.addClass("disabled-date"); // Add a class to style the disabled date
                }
                row.append(curr_date);
            }
        }
        // Append the last row and set the current year
        calendar_days.append(row);
        $(".year").text(year);
    }


    // Get the number of days in a given month/year
    function days_in_month(month, year) {
        var monthStart = new Date(year, month, 1);
        var monthEnd = new Date(year, month + 1, 1);
        return (monthEnd - monthStart) / (1000 * 60 * 60 * 24);
    }

    // Event handler for when a date is clicked
    function date_click(event) {
        $(".events-container").show(250);
        $("#dialog").hide(250);
        $(".active-date").removeClass("active-date");
        $(this).addClass("active-date");
        show_events(event.data.events, event.data.month, event.data.day);

    };

    // Event handler for when a month is clicked
    function month_click(event) {
        $(".events-container").show(250);
        $("#dialog").hide(250);
        var date = event.data.date;
        $(".active-month").removeClass("active-month");
        $(this).addClass("active-month");
        var new_month = $(".month").index(this);
        date.setMonth(new_month);
        init_calendar(date);
    }

    // Event handler for when the year right-button is clicked
    function next_year(event) {
        $("#dialog").hide(250);
        var date = event.data.date;
        var new_year = date.getFullYear() + 1;
        $("year").html(new_year);
        date.setFullYear(new_year);
        init_calendar(date);
    }

    // Event handler for when the year left-button is clicked
    function prev_year(event) {
        $("#dialog").hide(250);
        var date = event.data.date;
        var new_year = date.getFullYear() - 1;
        $("year").html(new_year);
        date.setFullYear(new_year);
        init_calendar(date);
    }

    // Event handler for clicking the new event button
    function new_event(event) {
        // if a date isn't selected then do nothing
        if ($(".active-date").length === 0)
            return;
        // remove red error input on click
        $("input").click(function () {
            $(this).removeClass("error-input");
        })
        // empty inputs and hide events
        $("#dialog input[type=text]").val('');
        $("#dialog input[type=number]").val('');
        $(".events-container").hide(250);
        $("#dialog").show(250);
        // Event handler for cancel button
        $("#cancel-button").click(function () {
            $("#name").removeClass("error-input");
            $("#count").removeClass("error-input");
            $("#dialog").hide(250);
            $(".events-container").show(250);
        });
        // Event handler for ok button
        $("#ok-button").unbind().click({ date: event.data.date }, function () {
            var date = event.data.date;
            var name = $("#name").val().trim();
            var fullName = $("#fullName").val().trim();
            var email = $("#email").val().trim();
            var time = $("#time").val();
            var day = parseInt($(".active-date").html());

            // Check if an event within 30 minutes already exists
            var existingEvents = check_events(day, date.getMonth() + 1, date.getFullYear());
            for (var i = 0; i < existingEvents.length; i++) {
                var existingTime = existingEvents[i]["time"].split(":");
                var newTime = time.split(":");
                if (Math.abs(existingTime[0] - newTime[0]) < 1 && Math.abs(existingTime[1] - newTime[1]) < 30) {
                    alert("Ya existe un evento dentro de los proximos 30 minutos!");
                    return;
                }
            }

            // Basic form validation
            if (name.length === 0) {
                $("#name").addClass("error-input");
            }
            else if (!/^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$/.test(time)) {
                $("#time").addClass("error-input");
            }
            else {
                $("#dialog").hide(250);
                console.log("new event");
                new_event_json(name, fullName, time, date, day, email);
                date.setDate(day);
                init_calendar(date);
            }
        });

    }

    // Adds a json event to event_data
    function new_event_json(name, fullName, time, date, day, email) {
        var event = {
            "occasion": name,
            "fullName": fullName,
            "time": time,
            "year": date.getFullYear(),
            "month": date.getMonth() + 1,
            "day": day,
            "email": email
        };
        event_data["events"].push(event);
    }

    // Display all events of the selected date in card views
    function show_events(events, month, day) {
        var fullName = $("#fullName").val().trim();
        // Clear the dates container
        $(".events-container").empty();
        $(".events-container").show(250);
        console.log(event_data["events"]);
        // If there are no events for this date, notify the user
        if (events.length === 0) {
            var event_card = $("<div class='event-card'></div>");
            var event_name = $("<div class='event-name'>No hay citas agendadas para esta fecha.</div>");
            $(event_card).css({ "border-left": "10px solid #FF1744" });
            $(event_card).append(event_name);
            $(".events-container").append(event_card);
        }
        else {
            // Go through and add each event as a card to the events container
            for (var i = 0; i < events.length; i++) {
                var event_card = $("<div class='event-card'></div>");
                $(event_card).data("eventData", events[i]);
                var event_subject = $("<div class='event-subject'>" + events[i]["occasion"] + "</div>");
                var event_time = $("<div class='event-time'>Hora: " + events[i]["time"] + "</div>");
                var event_name = $("<div class='event-fullName'>Nombre: " + events[i]["fullName"] + "</div>");
                var event_email = $("<div class='event-email'>Correo: " + events[i]["email"] + "</div>");
                var event_edit = $("<button class='button edit-button'>Edit</button>");
                var event_delete = $("<button class='button delete-button'>Delete</button>");

                // Attach event listeners to buttons
                event_edit.on("click", edit_event);
                event_delete.on("click", delete_event);

                if (events[i]["cancelled"] === true) {
                    $(event_card).css({
                        "border-left": "10px solid #FF1744"
                    });
                    event_time = $("<div class='event-cancelled'>Cancelled</div>");
                }
                $(event_card).append(event_subject).append(event_time).append(event_name).append(event_email)
                    .append(event_edit).append(event_delete);
                $(".events-container").append(event_card);
            }
        }
    }

    // Event handler for clicking the "Edit" button
    function edit_event() {
        // Get the event card associated with the clicked "Edit" button
        var event_card = $(this).closest('.event-card');

        // Find the elements within the event card to get the existing data
        var event_subject = event_card.find('.event-subject').text();
        var event_time = event_card.find('.event-time').text().replace("Hora: ", "");
        var event_name = event_card.find('.event-fullName').text().replace("Nombre: ", "");
        var event_email = event_card.find('.event-email').text().replace("Correo: ", ""); // Retrieve email from event card

        // Pre-fill input fields in the dialog with existing event data
        $("#name").val(event_subject);
        $("#time").val(event_time);
        $("#fullName").val(event_name);
        $("#email").val(event_email);

        // Show the edit dialog
        $("#dialog").show(250);

        // Event handler for cancel button
        $("#cancel-button").click(function () {
            $("#name").removeClass("error-input");
            $("#count").removeClass("error-input");
            $("#dialog").hide(250);
            $(".events-container").show(250);
        });

        // Event handler for ok button
        $("#ok-button").unbind().click(function () {
            var name = $("#name").val().trim();
            var newTime = $("#time").val();
            var newFullName = $("#fullName").val().trim();
            var newEmail = $("#email").val().trim();

            // Basic form validation
            if (name.length === 0) {
                $("#name").addClass("error-input");
            }
            else if (!/^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$/.test(newTime)) {
                $("#time").addClass("error-input");
            }
            else {
                // Update the content of the event card with the new data
                event_card.find('.event-subject').text(name);
                event_card.find('.event-time').text("Hora: " + newTime);
                event_card.find('.event-fullName').text("Nombre: " + newFullName);
                event_card.find('.event-email').text("Correo: " + newEmail); // Update email in event card

                // Hide the dialog
                $("#dialog").hide(250);
            }
        });
    }

    // Event handler for clicking the "Delete" button
    // Event handler for clicking the "Delete" button
    function delete_event(event) {
        // Remove the corresponding event card from the DOM
        var eventCard = $(this).closest(".event-card");
        eventCard.remove();

        // Remove the deleted event from the event_data object
        var eventData = eventCard.data("eventData");
        var index = event_data["events"].indexOf(eventData);
        if (index !== -1) {
            event_data["events"].splice(index, 1);
        }

        // Optionally, handle backend logic (e.g., delete from a database)

        // Update displayed events based on the updated event data
        var activeDate = $(".active-date");
        var day = parseInt(activeDate.html());
        var month = $(".active-month").index();
        var year = $(".year").text();
        var events = check_events(day, month + 1, year);
        show_events(events, months[month], day);
    }

    // Given data for events in JSON format
    var event_data = {
        "events": [
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10,
                "cancelled": true
            },
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10,
                "cancelled": true
            },
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10,
                "cancelled": true
            },
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10
            },
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10,
                "cancelled": true
            },
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10
            },
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10,
                "cancelled": true
            },
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10
            },
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10,
                "cancelled": true
            },
            {
                "occasion": " Repeated Test Event ",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 10
            },
            {
                "occasion": " Test Event",
                "invited_count": 120,
                "year": 2020,
                "month": 5,
                "day": 11
            }
        ]
    };

    const months = [
        "Marzo",
        "Abril",
        "Mayo",
        "Junio",
        "Julio",
        "Agosto",
        "Septiembre",
        "Octubre",
        "Noviembre",
        "Diciembre"
    ];

})(jQuery);
