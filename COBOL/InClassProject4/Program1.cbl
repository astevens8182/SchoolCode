       IDENTIFICATION DIVISION.
       PROGRAM-ID. CH10PPB.
      ************************************************************
      *  Sample         -  This an example of a double-level     *
      *                    control break.  The major field is    *
      *                    DEPT and the minor field is TERR      *
      ************************************************************
       ENVIRONMENT DIVISION.
       INPUT-OUTPUT SECTION.
       FILE-CONTROL.
           SELECT IN-EMPLOYEE-FILE
               ASSIGN TO 'W:\CIS 253\Projects\INCLASSPROJECT4\CH10PP.DAT'
               ORGANIZATION IS LINE SEQUENTIAL.

           SELECT OUT-REPORT-FILE
               ASSIGN TO 'W:\CIS 253\Projects\INCLASSPROJECT4\CH10PP.RPT'
               ORGANIZATION IS LINE SEQUENTIAL.
      *
       DATA DIVISION.
       FILE SECTION.
       FD  IN-EMPLOYEE-FILE.
       01  IN-EMPLOYEE-REC.
           05  IN-DEPT                 PIC XX.
           05  IN-TERR                 PIC XX.
           05  IN-EMPLOYEE-NO          PIC X(3).
           05  IN-EMPLOYEE-NAME        PIC X(20).
           05  IN-ANNUAL-SALARY        PIC 9(5).

       FD  OUT-REPORT-FILE.
       01  OUT-REPORT-REC              PIC X(80).

       WORKING-STORAGE SECTION.
       01  WS-WORK-AREAS.
           05  ARE-THERE-MORE-RECORDS  PIC X(3)     VALUE 'YES'.
               88  MORE-RECORDS                     VALUE 'YES'.
               88  NO-MORE-RECORDS                  VALUE 'NO '.

           05  FIRST-RECORD            PIC X(3)     VALUE 'YES'.

           05  WS-LINE-CTR             PIC 99       VALUE ZEROS.
           05  WS-PAGE-CTR             PIC 999      VALUE ZEROS.

           05  WS-DEPT-SALARY          PIC 9(7)V99  VALUE ZEROS.
           05  WS-TERR-SALARY          PIC 9(6)V99  VALUE ZEROS.

           05  WS-DEPT-HOLD            PIC XX       VALUE ZEROS.
           05  WS-TERR-HOLD            PIC XX       VALUE ZEROS.

           05  WS-TOTAL-SALARY         PIC 9(8)V99  VALUE ZEROS.

           05  WS-T-DATE.
               10  WS-IN-YR            PIC 9(4).
               10  WS-IN-MO            PIC 9(2).
               10  WS-IN-DAY           PIC 9(2).

       01  HL-HEADING1.
           05                          PIC X(23)    VALUE SPACES.
           05                          PIC X(44)
              VALUE 'A L P H A  D E P A R T M E N T  S T O R E'.
           05                          PIC X(5)
              VALUE 'PAGE '.
           05  HL-OUT-PAGE             PIC ZZ9.
           05                          PIC X(5)     VALUE SPACES.

       01  HL-HEADING2.
           05                          PIC X(29)    VALUE SPACES.
           05                          PIC X(24)
                VALUE 'PAYROLL FOR THE WEEK OF'.
           05  HL-TODAYS-DATE.
               10  HL-OUT-MO           PIC 99.
               10                      PIC X        VALUE '/'.
               10  HL-OUT-DAY          PIC 99.
               10                      PIC X        VALUE '/'.
               10  HL-OUT-YR           PIC 9(4).
           05                          PIC X(17)    VALUE SPACES.

       01  HL-HEADING3.
           05                          PIC X(17)    VALUE SPACES.
           05                          PIC X(15)
               VALUE 'EMPLOYEE NUMBER'.
           05                          PIC X(9)     VALUE SPACES.
           05                          PIC X(13)
               VALUE 'EMPLOYEE NAME'.
           05                          PIC X(8)     VALUE SPACES.
           05                          PIC X(13)
               VALUE 'ANNUAL SALARY'.
           05                          PIC X(5)     VALUE SPACES.

       01  DL-SALARY-LINE.
           05                          PIC X(28)    VALUE SPACES.
           05  DL-OUT-EMPLOYEE-NO      PIC X(3).
           05                          PIC X(10)    VALUE SPACES.
           05  DL-OUT-EMPLOYEE-NAME    PIC X(20).
           05                          PIC XX       VALUE SPACES.
           05  DL-OUT-ANNUAL-SALARY    PIC $$$,$$$.99.
           05                          PIC X(7)     VALUE SPACES.
       01  DL-TERRITORY-TOTAL-LINE.
           05                          PIC X(28)    VALUE SPACES.
           05                          PIC X(34)
              VALUE 'TOTAL SALARY FOR TERRITORY IS '.
           05  DL-OUT-TERR-SALARY      PIC $$$$,$$$.99.
           05                          PIC X(7)     VALUE SPACES.

       01  DL-DEPARTMENT-TOTAL-LINE.
           05                          PIC X(36)    VALUE SPACES.
           05                          PIC X(31)
              VALUE 'TOTAL SALARY FOR DEPARTMENT IS '.
           05  DL-OUT-DEPT-SALARY      PIC $$,$$$,$$$.99.

       01  DL-FINAL-TOTAL-LINE.
           05                          PIC X(40)    VALUE SPACES.
           05                          PIC X(25)
              VALUE 'TOTAL OF ALL SALARIES IS '.
           05  DL-OUT-TOT-ANN-SALARY   PIC $$$,$$$,$$$.99.
           05                          PIC X(1)     VALUE SPACE.

       01  DL-DEPT-HEADING.
           05                          PIC X(14)    VALUE SPACES.
           05                          PIC X(13)
              VALUE 'DEPARTMENT - '.
           05  DL-OUT-DEPT             PIC XX.
           05                          PIC X(51)    VALUE SPACES.

       01  DL-TERR-HEADING.
           05                          PIC X(14)    VALUE SPACES.
           05                          PIC X(12)
              VALUE 'TERRITORY - '.
           05  DL-OUT-TERR             PIC XX.
           05                          PIC X(52)    VALUE SPACES.

       01  HL-HEADING-FINAL.
           05                          PIC X(9)     VALUE SPACES.
           05                          PIC X(13)
              VALUE 'END OF REPORT'.
           05                          PIC X(58)    VALUE SPACES.
      *
       PROCEDURE DIVISION.
      **********************************************************
      *  100-MAIN-MODULE - Controls direction of program logic *
      **********************************************************
       100-MAIN-MODULE.
           PERFORM 800-INITIALIZATION-RTN.
           PERFORM 200-DATE-ACCEPT-RTN.

           PERFORM UNTIL NO-MORE-RECORDS
               READ IN-EMPLOYEE-FILE
                  AT END
                     MOVE 'NO ' TO ARE-THERE-MORE-RECORDS
                  NOT AT END
                     PERFORM 400-CALC-RTN
               END-READ
           END-PERFORM.

           PERFORM 500-DEPT-BREAK.

           PERFORM 700-END-PROGRAM-RTN.

           PERFORM 900-END-OF-JOB-RTN.

           STOP RUN.
      ***********************************************************
      *  200-DATE-ACCEPT-RTN - Performed from 100-MAIN-MODULE.  *
      *       Gets the current date from the operating system.  *
      ***********************************************************
       200-DATE-ACCEPT-RTN.
           MOVE FUNCTION CURRENT-DATE TO WS-T-DATE
           MOVE WS-IN-MO TO HL-OUT-MO
           MOVE WS-IN-YR TO HL-OUT-YR
           MOVE WS-IN-DAY TO HL-OUT-DAY.

      ***********************************************************
      *    300-HEADING-RTN  Performed from 100-MAIN-MODULE,     *
      *                     400-CALC-RTN, 500-DEPT-BREAK and    *
      *                     600-TER--BREAK. Prints the headings *
      *                     on a new page.                      *
      ***********************************************************
       300-HEADING-RTN.
           ADD 1 TO WS-PAGE-CTR.
           MOVE WS-PAGE-CTR TO HL-OUT-PAGE
           MOVE WS-TERR-HOLD TO DL-OUT-TERR
           MOVE WS-DEPT-HOLD TO DL-OUT-DEPT
           MOVE 0 TO WS-LINE-CTR
           WRITE OUT-REPORT-REC FROM HL-HEADING1
               AFTER ADVANCING PAGE
           WRITE OUT-REPORT-REC FROM HL-HEADING2
               AFTER ADVANCING 2 LINES
           WRITE OUT-REPORT-REC FROM DL-DEPT-HEADING
               AFTER ADVANCING 2 LINES
           WRITE OUT-REPORT-REC FROM DL-TERR-HEADING
               AFTER ADVANCING 2 LINES
           WRITE OUT-REPORT-REC FROM HL-HEADING3
               AFTER ADVANCING 2 LINES.

      **********************************************************
      *  400-CALC-RTN - Performed from 100-MAIN-MODULE         *
      *                 Controls TERR and DEPT breaks          *
      *                 Prints out employee information        *
      **********************************************************
       400-CALC-RTN.
           EVALUATE TRUE
               WHEN FIRST-RECORD = 'YES'
                   MOVE IN-DEPT TO WS-DEPT-HOLD
                   MOVE IN-TERR TO WS-TERR-HOLD
                   PERFORM 300-HEADING-RTN
                   MOVE 'NO ' TO FIRST-RECORD
               WHEN IN-DEPT NOT = WS-DEPT-HOLD
                   PERFORM 500-DEPT-BREAK
               WHEN IN-TERR NOT = WS-TERR-HOLD
                   PERFORM 600-TERR-BREAK
           END-EVALUATE.

           IF WS-LINE-CTR IS GREATER THAN 25
               PERFORM 300-HEADING-RTN
           END-IF.

           MOVE IN-EMPLOYEE-NO TO DL-OUT-EMPLOYEE-NO
           MOVE IN-EMPLOYEE-NAME TO DL-OUT-EMPLOYEE-NAME
           MOVE IN-ANNUAL-SALARY TO DL-OUT-ANNUAL-SALARY
           WRITE OUT-REPORT-REC FROM DL-SALARY-LINE
               AFTER ADVANCING 2 LINES
           ADD IN-ANNUAL-SALARY TO WS-TERR-SALARY
           ADD 1 TO WS-LINE-CTR.
      *********************************************************
      *   500-DEPT-BREAK - Performed from 100-MAIN-MODULE and *
      *                    400-CALC-RTN, Forces a TERR break  *
      *                    then prints dept totals            *
      *********************************************************
       500-DEPT-BREAK.
           PERFORM 600-TERR-BREAK.

           ADD WS-DEPT-SALARY TO WS-TOTAL-SALARY.
           MOVE WS-DEPT-SALARY TO DL-OUT-DEPT-SALARY.
           WRITE OUT-REPORT-REC FROM DL-DEPARTMENT-TOTAL-LINE
               AFTER ADVANCING 3 LINES.

           ADD 1 TO WS-LINE-CTR.

           IF  MORE-RECORDS
               MOVE ZEROS TO WS-DEPT-SALARY
               MOVE IN-DEPT TO WS-DEPT-HOLD
               PERFORM 300-HEADING-RTN
           END-IF.

      ********************************************************
      *  600-TERR-BREAK - Performed from 400-CALC-RTN and    *
      *                   500-DEPT-BREAK, controls TERR      *
      *                   break and prints TERR totals       *
      ********************************************************
       600-TERR-BREAK.
           ADD WS-TERR-SALARY TO WS-DEPT-SALARY.
           MOVE WS-TERR-SALARY TO DL-OUT-TERR-SALARY.
           WRITE OUT-REPORT-REC FROM DL-TERRITORY-TOTAL-LINE
               AFTER ADVANCING 3 LINES.

           ADD 1 TO WS-LINE-CTR.

           IF  MORE-RECORDS
               MOVE IN-TERR TO WS-TERR-HOLD
               MOVE ZEROS TO WS-TERR-SALARY
           END-IF.

           IF MORE-RECORDS AND IN-DEPT IS EQUAL TO WS-DEPT-HOLD
               PERFORM 300-HEADING-RTN
           END-IF.

      ************************************************************
      *  700-END-PROGRAM-RTN - Performed from 100-MAIN-MODULE    *
      *                        Prints total of all salaries      *
      ************************************************************
       700-END-PROGRAM-RTN.
           MOVE WS-TOTAL-SALARY TO DL-OUT-TOT-ANN-SALARY.
           WRITE OUT-REPORT-REC FROM DL-FINAL-TOTAL-LINE
               AFTER ADVANCING 3 LINES.
           WRITE OUT-REPORT-REC FROM HL-HEADING-FINAL
               AFTER ADVANCING 2 LINES.

      ************************************************************
      * 800-INITIALIZATION-RTN - Performed from 100-MAIN-MODULE  *
      *                          Controls opening of files       *
      ************************************************************
       800-INITIALIZATION-RTN.
           OPEN INPUT IN-EMPLOYEE-FILE
                OUTPUT OUT-REPORT-FILE.

      ***********************************************************
      * 900-END-OF-JOB-RTN - Performed from 100-MAIN-MODULE     *
      *                      Closes the files                   *
      ***********************************************************
       900-END-OF-JOB-RTN.
           CLOSE IN-EMPLOYEE-FILE
                 OUT-REPORT-FILE.
