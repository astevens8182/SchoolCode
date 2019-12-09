       IDENTIFICATION DIVISION.
      ******************************************************************
      *                   ALEX STEVENS: PROJECT 3 10/09/2018           *
      ******************************************************************
       PROGRAM-ID.
           PROJECT3.
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
       DATA DIVISION.
       FILE SECTION.
       
       WORKING-STORAGE SECTION. 
       01 WORK-AREAS.
           05 MORE-HOUSES                              PIC X.
           05 BORROW-AMOUNT                            PIC 9(6).
           05 HOUSE-PRICE                              PIC 9(6).
           05 MAX-BORROW                               PIC 9(6).
           05 DOWN-PAY                                 PIC 9(6).
           05 DOWN-PAY-OUT                             PIC $$$$,$$9.
       SCREEN SECTION.
       01 ENTRY-SCREEN-BORROW.
           05 BLANK SCREEN
              FOREGROUND-COLOR  12
              BACKGROUND-COLOR 15.
           05 LINE 2 COLUMN 3 VALUE "ENTER THE AMOUNT THAT YOU WISH TO BORROW: ".
           05 COLUMN 45 PIC 9(6) TO BORROW-AMOUNT.
       01 ENTRY-SCREEN-HOUSE-VALUE.
           05 LINE 3 COLUMN 3 VALUE "ENTER THE PRICE THE HOUSE IS VALUED AT: ".
           05 COLUMN 45 PIC 9(6) TO HOUSE-PRICE.
       01 ERROR-LOAN-GREATER-SCREEN.
           05 LINE 6 COLUMN 3 VALUE "THE BANK DOSE NOT GIVE LOANS FOR HOMES VALUED OVER $500,000".
          
       01 ERROR-AMOUNT-GREATER-50PERCENT-SCREEN.
           05 LINE 6 COLUMN 3 VALUE "YOU MAY NOT BORROW MORE THAN 50% OF THE HOME'S VALUE".
       01 SUCCESS-SCREEN.
           05 LINE 6 COLUMN 3 VALUE "THE REQUIRED DOWN PAYMENT IS ".
           05 COLUMN 30 PIC $$$$,$$9 FROM DOWN-PAY-OUT.
       01 MORE-HOUSES-SCREEN.
           05 LINE 8 COLUMN 3  VALUE "DO YOU WISH TO CALCULATE FOR ANY MORE HOMES? <Y/N>".
           05 COLUMN 53 PIC X TO MORE-HOUSES.
           
           

       PROCEDURE DIVISION.
        000-MAIN-MODUEL.
              PERFORM 200-PROCESS-MODUEL
            UNTIL MORE-HOUSES =  "N" OR "n"
           STOP run. 

       200-PROCESS-MODUEL.
           DISPLAY ENTRY-SCREEN-BORROW.
           ACCEPT ENTRY-SCREEN-BORROW.
           DISPLAY ENTRY-SCREEN-HOUSE-VALUE.
           ACCEPT ENTRY-SCREEN-HOUSE-VALUE.
           PERFORM 300-DOWN-PAYMENT-MODUEL.
           
           DISPLAY MORE-HOUSES-SCREEN.
          ACCEPT MORE-HOUSES-SCREEN.
         
       300-DOWN-PAYMENT-MODUEL.
          IF BORROW-AMOUNT IS > 500000 THEN
               DISPLAY ERROR-LOAN-GREATER-SCREEN

          ELSE IF BORROW-AMOUNT > (HOUSE-PRICE * 0.50) THEN
               DISPLAY ERROR-AMOUNT-GREATER-50PERCENT-SCREEN
           

       ELSE
          IF BORROW-AMOUNT IS < 60000 THEN
              COMPUTE DOWN-PAY = BORROW-AMOUNT * 0.04
          END-IF
          IF BORROW-AMOUNT IS > 59000 AND BORROW-AMOUNT IS <= 90000 THEN 
              COMPUTE DOWN-PAY = 2400 + ((BORROW-AMOUNT - 60000) * 0.08)
          END-IF
            IF BORROW-AMOUNT IS > 90000 THEN 
               COMPUTE DOWN-PAY = 4800 + ((BORROW-AMOUNT - 90000)* 0.10)
           END-IF
        
           MOVE DOWN-PAY TO DOWN-PAY-OUT
           DISPLAY SUCCESS-SCREEN
           END-IF.
       
           
     
          


         



