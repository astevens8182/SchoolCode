       
      ***************************************************
      *    PROJECT 2                                    *                                              
      *    AUTHOR: Alex Stevens                         *
      ***************************************************


       IDENTIFICATION DIVISION.
       PROGRAM-ID.PROJECT2.
           
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT CUST-FILE
               ASSIGN TO "W:\CIS 253\Projects\CIS253PROJECT2INFO\CH0601.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.
           SELECT PRINT-FILE
               ASSIGN TO "W:\CIS 253\Projects\CIS253PROJECT2INFO\CH0601.RPT"
               ORGANIZATION IS LINE SEQUENTIAL.

       DATA DIVISION.
       FILE SECTION.

       FD CUST-FILE
           RECORD CONTAINS 32 CHARACTERS.
       01  CUST-FILE-IN.
           05 CUST-NAME-FIRST-IN               PIC X(1).
           05 CUST-NAME-SECOND-IN              PIC X(1).
           05 CUST-NAME-LAST-IN                PIC X(10).
           05 DATE-OF-TRANS-MONTH-IN           PIC X(2).
           05 DATE-OF-TRANS-YEAR-IN            PIC X(4).
           05 AMT-OF-TRANS-IN                  PIC X(6).

       FD PRINT-FILE
          RECORD CONTAINS 80 CHARACTERS.
       01 PRINT-REC                            PIC X(80).

       WORKING-STORAGE SECTION.
       01 WORK-AREAS.
          05 ARE-THERE-MORE-RECORDS            PIC XXX
               VALUE 'YES'.
          05 WS-DATE.
             10 WS-YEAR                        PIC 9999.
             10 WS-MONTH                       PIC 99.
             10 WS-DAY                         PIC 99.
          05 WS-PAGE-CT                        PIC 99
                VALUE ZERO.
          05 WS-LINE-CT                        PIC 99
                VALUE ZERO.
       
       01 HDR1-OUT.
          05                                   PIC X(25)
                   VALUE SPACES.
          05                                   PIC X(20)
                   VALUE 'CUSTOMER REPORT'.
          05 DATE-OUT.
             10 MONTH-OUT                      PIC 99.
             10                                PIC X
                VALUE '/'.
             10 DAY-OUT                        PIC 99.
             10                                PIC X
                VALUE '/'.
             10 YEAR-OUT                       PIC 9999.
          05                                   PIC X(2)
                VALUE SPACES.
          05                                   PIC X(5)
                VALUE 'PAGE'.
          05 PAGE-OUT                          PIC Z9.

       01 HDR2-OUT.
          05                                   PIC X(40)
               VALUE SPACES.
          05                                   PIC X(40)
               VALUE 'ALEX STEVENS'.
       01 HDR3-OUT.
          05                                   PIC X(15)
               VALUE SPACES.
          05                                   PIC X(10)
               VALUE 'NAME'.
          05                                   PIC X(2)
               VALUE SPACES.
          05                                   PIC X(20)
               VALUE 'DATE OF TRANSACTION'.
          05                                   PIC X(6)
               VALUE SPACES.
          05                                   PIC X(21)
               VALUE 'AMOUNT OF TRANSACTION'.
       
       01 DETAIL-REC-OUT.
          05                                   PIC X(13)
               VALUE SPACES.
          05 CUST-NAME-FIRST-OUT               PIC X(1).
          05                                   PIC X
               VALUE '.'.
          05 CUST-NAME-SECOND-OUT              PIC X(1).
          05                                   PIC X(1)
               VALUE '.'.
          05 CUST-NAME-LAST-OUT                PIC X(8).
          05                                   PIC X(8)
               VALUE SPACES.
          05 DATE-OF-TRANS-MONTH-OUT           PIC X(2).
          05                                   PIC X
               VALUE '/'.
          05 DATE-OF-TRANS-YEAR-OUT            PIC X(4).
          05                                   PIC X(19).
          05 AMT-OF-TRANS-OUT                  PIC $$$,$$9.
          
       PROCEDURE DIVISION.
       100-MAIN-MODULE.
           OPEN INPUT  CUST-FILE
                OUTPUT PRINT-FILE.

           MOVE FUNCTION CURRENT-DATE TO WS-DATE.
           MOVE WS-MONTH TO MONTH-OUT.
           MOVE WS-DAY TO DAY-OUT.
           MOVE WS-YEAR TO YEAR-OUT.

           PERFORM 200-HDG-RTN.

           PERFORM UNTIL ARE-THERE-MORE-RECORDS = 'NO '
               READ CUST-FILE
                    AT END
                       MOVE 'NO ' TO ARE-THERE-MORE-RECORDS
                    NOT AT END
                       PERFORM 300-REPORT-RTN
               END-READ
           END-PERFORM.

           CLOSE CUST-FILE
                 PRINT-FILE.

           STOP RUN.

       200-HDG-RTN.
           ADD 1 TO WS-PAGE-CT.
           MOVE WS-PAGE-CT TO PAGE-OUT.
           WRITE PRINT-REC FROM HDR1-OUT
                AFTER ADVANCING PAGE.
           WRITE PRINT-REC FROM HDR2-OUT
                AFTER ADVANCING 2 LINES.
           WRITE PRINT-REC FROM HDR3-OUT
                AFTER ADVANCING 2 LINES.
           MOVE 5 TO WS-LINE-CT.

        300-REPORT-RTN.
           IF WS-LINE-CT >= 25
               PERFORM 200-HDG-RTN
           END-IF.
           MOVE SPACES TO PRINT-REC.
           MOVE CUST-NAME-FIRST-IN TO CUST-NAME-FIRST-OUT.
           MOVE CUST-NAME-SECOND-IN  TO CUST-NAME-SECOND-OUT.
           MOVE CUST-NAME-LAST-IN TO CUST-NAME-LAST-OUT.
           MOVE DATE-OF-TRANS-MONTH-IN TO DATE-OF-TRANS-MONTH-OUT.
           MOVE DATE-OF-TRANS-YEAR-IN TO DATE-OF-TRANS-YEAR-OUT.
           MOVE AMT-OF-TRANS-IN TO AMT-OF-TRANS-OUT.
           WRITE PRINT-REC FROM DETAIL-REC-OUT
               AFTER ADVANCING 1 LINE.
           ADD 1 TO WS-LINE-CT.