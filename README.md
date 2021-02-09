# ScoreBoard
I did not add validation of the input data, so as not to complicate the code. Therefore, we can create duplicate matches and this should be taken into account when performing a delete or update operation.

I decided to hardcode the database emulation in a static class, so as not to complicate the code, and we could access this data directly from tests and other places in our application. Ideally, this should have been done in a regular class, which we threw into the service using dependency injection and in tests we emulated data by creating mock objects

The demo project was written "on its knees" in order to be able to clearly see the results of code execution.

