       IDENTIFICATION DIVISION.
       PROGRAM-ID. PROJECT4.
       AUTHOR. 
      *ALEX STEVENS
       ENVIRONMENT DIVISION.

       INPUT-OUTPUT SECTION.
       SELECT STUDENT-FILE
           ASSIGN TO "W:\CIS 253\Projects\CIS253PROJECT4INFO\CH1004.DAT"
               ORGANIZATION IS LINE SEQUENTIAL.

       SELECT STUDENT-REPORT
           ASSIGN TO "W:\CIS 253\Projects\CIS253PROJECT4INFO\CH1004.RPT"
               ORGANIZATION IS LINE SEQUENTIAL.

       DATA DIVISION.
       FILE SECTION.

       FD  STUDENT-FILE
           RECORD CONTAINS 38 CHARACTERS.
       01  STUDENT-REC-IN.
           05  SOC-SEC-NO-IN               PIC X(9).
           05  NAME-IN                     PIC X(21).
           05  CLASS-IN                    PIC X.
               88  FRESHMAN                    VALUE "1".
               88  SOPHOMORE                   VALUE "2".
               88  JUNIOR                      VALUE "3".
               88  SENIOR                      VALUE "4".
           05  SCHOOL-IN                   PIC X.
               88  BUSINESS                    VALUE "1".
               88  ARTS                        VALUE "2".
               88  ENGINEERING                 VALUE "3".
           05  GPA-IN                      PIC 9V99.
           05  CREDITS-IN                  PIC 9(3).

       FD  STUDENT-REPORT
           RECORD CONTAINS 80 CHARACTERS.
       01  REPORT-OUT                      PIC X(80).

       WORKING-STORAGE SECTION.
       01  WS-WORK-AREAS.
           05  ARE-THERE-MORE-RECORDS  PIC X(3)     VALUE 'YES'.
               88  MORE-RECORDS                     VALUE 'YES'.
               88  NO-MORE-RECORDS                  VALUE 'NO '.

           05  FIRST-RECORD            PIC X(3)     VALUE 'YES'.
           05  WS-LINE-CTR             PIC 99       VALUE ZEROS.
           05  WS-PAGE-CTR             PIC 999      VALUE ZEROS.

           05  WS-CLASS-HOLD           PIC XX       VALUE ZEROS.

           05  WS-CLASS-FRESHMAN       PIC 9V99     VALUE ZEROS.
           05  WS-CLASS-SOPHOMORE      PIC 9V99     VALUE ZEROS.
           05  WS-CLASS-JUNIOR         PIC 9V99     VALUE ZEROS.
           05  WS-CLASS-SENIOR         PIC 9V99     VALUE ZEROS.
           05  WS-FRESHMAN-COUNT       PIC X        VALUE ZEROS.
           05  WS-SOPHMORE-COUNT       PIC X        VALUE ZEROS.
           05  WS-JUNIOR-COUNT         PIC X        VALUE ZEROS.
           05  WS-SENIOR-COUNT         PIC X        VALUE ZEROS.

           05 WS-SCHOOL-HOLD           PIC X(10)    VALUE ZEROS.


           05 WS-T-DATE.
               10  WS-IN-YR            PIC 9(4).
               10  WS-IN-MO            PIC 9(2).
               10  WS-IN-DAY           PIC 9(2).


       01 HL-HEADING1.
           05                          PIC X(23)    VALUE SPACES.
           05                          PIC X(44)
               VALUE 'PASS EM STATE COLLEGE'.
       01 HL-HEADING2.
           05                          PIC X(24)    
               VALUE 'ALEX PROGRAMMER'.
       01 HL-HEADING3.
           05                          PIC X(14) VALUE SPACES.
           05                          PIC X(10)
               VALUE 'SCHOOL: '.
           05 SCHOOL-OUT               PIC X.

           05                          PIC X(5)
               VALUE 'PAGE'.
           05  HL-OUT-PAGE             PIC ZZ9.
           05                          PIC X(5) VALUE SPACES.

           05  HL-TODAYS-DATE.
               10 HL-OUT-MO            PIC 99.
               10                      PIC X    VALUE '/'.
               10 HL-OUT-DAY           PIC 99.
               10                      PIC X    VALUE '/'.
               10 HL-OUT-YR            PIC 9(4).
               10                      PIC X(10) VALUE SPACES.
       01  HL-HEADING4.
           05                          PIC X(17) VALUE SPACES.
           05                          PIC X(5)
               VALUE 'CLASS'.
           05                          PIC X(9)  VALUE SPACES.
           05                          PIC X(11)
               VALUE 'AVERAGE GPA'.
           05                          PIC X(8) VALUE SPACES.
       
       01 DL-CLASS-LINE.
           05                          PIC X(28) VALUE SPACES.
           05 DL-OUT-CLASS             PIC X(15).
           05                          PIC X(9)  VALUE SPACES.
           05 DL-OUT-AVG-GPA           PIC X(4).
       01 DL-FRESHMAN-GPA.
           05                          PIC X(9)
               VALUE 'FRESHMAN'.
           05 DL-GPA-OUT               PIC 9V99.
       01 DL-SOPHOMORE-GPA.
           05                          PIC X(9)
               VALUE 'SOPHOMORE'.
           05 DL-GPA-OUT         PIC 9V99.
       01 DL-JUNIOR-GPA.
           05                          PIC X(9)
               VALUE 'JUNIOR'.
           05 DL-GPA-OUT            PIC 9V99.
       01 DL-SENIOR-GPA.
           05                          PIC X(9)
               VALUE 'SENIOR'.
           05 DL-GPA-OUT            PIC 9V99.

       PROCEDURE DIVISION.

       100-MAIN-MODULE.
           PERFORM 800-INITIALIZATION-RTN.
           PERFORM 200-DATE-ACCEPT-RTN.

           PERFORM UNTIL NO-MORE-RECORDS
               READ STUDENT-FILE
                  AT END
                     MOVE 'NO ' TO ARE-THERE-MORE-RECORDS
                  NOT AT END
                     PERFORM 400-CALC-RTN
               END-READ
           END-PERFORM.
           
           PERFORM 500-CLASS-BREAK.

           PERFORM 700-END-PROGRAM-RTN.

           PERFORM 900-END-OF-JOB-RTN.

           STOP RUN.

       200-DATE-ACCEPT-RTN.
           MOVE FUNCTION CURRENT-DATE TO WS-T-DATE
           MOVE WS-IN-MO TO HL-OUT-MO
           MOVE WS-IN-YR TO HL-OUT-YR
           MOVE WS-IN-DAY TO HL-OUT-DAY.

       
       300-HEADING-RTN.
           ADD 1 TO WS-PAGE-CTR.
           MOVE WS-PAGE-CTR TO HL-OUT-PAGE
           MOVE WS-CLASS-FRESHMAN TO DL-OUT-FRESHMAN
           MOVE WS-CLASS-SOPHOMORE TO DL-OUT-SOPHOMORE
           MOVE WS-CLASS-JUNIOR TO DL-OUT-JUNIOR
           MOVE WS-CLASS-SENIOR TO DL-OUT-SENIOR
           MOVE 0 TO WS-LINE-CTR
           WRITE  REPORT-OUT FROM HL-HEADING1
               AFTER ADVANCING PAGE
           WRITE REPORT-OUT FROM HL-HEADING2
               AFTER ADVANCING 2 LINES
           WRITE REPORT-OUT FROM HL-HEADING3
               AFTER ADVANCING 2 LINES
           WRITE REPORT-OUT FROM DL-CLASS-LINE
               AFTER ADVANCING 2 LINES
        WRITE REPORT-OUT FROM HL-HEADING4
               AFTER ADVANCING 2 LINE.
       
       400-CALC-RTN.
           EVALUATE TRUE
               WHEN FIRST-RECORD = 'YES'
                    MOVE WS-CLASS-FRESHMAN TO DL-OUT-FRESHMAN
                    MOVE WS-CLASS-SOPHOMORE TO DL-OUT-SOPHOMORE
                    MOVE WS-CLASS-JUNIOR TO DL-OUT-JUNIOR
                    MOVE WS-CLASS-SENIOR TO DL-OUT-SENIOR 
                    PERFORM 300-HEADING-RTN
                    MOVE 'NO ' TO FIRST-RECORD
               WHEN CLASS-IN NOT = WS-CLASS-HOLD
                   PERFORM 500-CLASS-BREAK
               WHEN SCHOOL-IN NOT = WS-SCHOOL-HOLD
                   PERFORM 600-SCHOOL-BREAK
           END-EVALUATE.

           IF WS-LINE-CTR IS GREATER THAN 25
               PERFORM 300-HEADING-RTN

           END-IF.
           
           MOVE CLASS-IN TO DL-OUT-CLASS
           MOVE SCHOOL-IN TO DL-SCHOOL-OUT
           MOVE GPA-IN TO DL-GPA-OUT of
       500-CLASS-BREAK.
       600-SCHOOL-BREAK.
       700-END-PROGRAM-RTN.
       800-INITIALIZATION-RTN.
       900-END-OF-JOB-RTN.
       