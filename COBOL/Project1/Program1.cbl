       identification division.

       program-id. project1
      *AUTHOR. Alex Stevens
       
       data division.
       
       working-storage section.
       01 keyed-fields.
           05 employee-name-in          pic x(30).
           05 salary-in                 pic 9(6).

       01 displayed-output.
           05 employee-name-out         pic x(30).
           05 state-tax                 pic 9(5).99.
           05 federal-tax               pic 9(6).99.

       01 more-data                     pic x(3) value 'YES'.

       procedure division.

       100-main-module.
           perform until more-data = 'NO'
               display 'Enter Employee Name (30 Characters Max)'
               accept employee-name-in
               display 'Enter Salary as 6 Digits Max'
               accept salary-in
               perform 200-process-and-create-output
               display 'Is There More data (YES/NO)?'
               accept more-data
           end-perform
           display 'End of Job'.
           stop run.

       200-process-and-create-output.
           move employee-name-in to employee-name-out.
           multiply salary-in by .15 giving federal-tax.
           multiply salary-in by .05 giving state-tax.
           display 'Federal Tax for ', employee-name-out, ' is ', federal-tax.
           display 'State Tax for ', employee-name-out, ' is ', state-tax.

       
