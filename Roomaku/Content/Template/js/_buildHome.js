$(document).ready(function () {
    //var sizes = ['20x30', '20x50', '50x50', '100x100', '100x10',
    //          '70x90', '80x80'
    //];

    //debugger;

    //var sizes = new Bloodhound({
    //    datumTokenizer: Bloodhound.tokenizers.whitespace,
    //    queryTokenizer: Bloodhound.tokenizers.whitespace,
    //    // `states` is an array of state names defined in "The Basics"
    //    local: sizes
    //});

    //$('#bloodhound .typeahead').typeahead({
    //    hint: true,
    //    highlight: true,
    //    minLength: 1
    //},
    //{
    //    name: 'sizes',
    //    source: sizes
    //});
    debugger;
    var substringMatcher = function (strs) {
        return function findMatches(q, cb) {
            var matches, substringRegex;

            // an array that will be populated with substring matches
            matches = [];

            // regex used to determine if a string contains the substring `q`
            substrRegex = new RegExp(q, 'i');

            // iterate through the pool of strings and for any string that
            // contains the substring `q`, add it to the `matches` array
            $.each(strs, function (i, str) {
                if (substrRegex.test(str)) {
                    matches.push({ value: str });
                }
            });

            cb(matches);
        };
    };

    var states = ['20x30', '20x50', '50x50', '100x100', '100x10',
                 '70x90', '80x80']

    //var states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California',
    //  'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii',
    //  'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana',
    //  'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota',
    //  'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire',
    //  'New Jersey', 'New Mexico', 'New York', 'North Carolina', 'North Dakota',
    //  'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island',
    //  'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont',
    //  'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'
    //];

    $('#the-basics .typeahead').typeahead({
        hint: true,
        highlight: true,
        minLength: 1
    },
    {
        name: 'states',
        source: substringMatcher(states)
    });
    //.on('typeahead:selected', function (event, selection) {

    //    // the second argument has the info you want
    //    alert(selection.value);

    //    // clearing the selection requires a typeahead method
    //    $('.typeahead').typeahead('setQuery', '');
        
    //});
        
})