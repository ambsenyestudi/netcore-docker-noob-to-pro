# Dockerfile and dockerignore

This time let us start in reverse. Since when using docker we want to avoid oversizing our image we must write a *.dockerignore* file.
How to write a docker ignore file:
1. At the root folder of your source (where our solution lives):
2. Create a file called *.dockerignore*
3. Inside this fill you must specify what folder to ignore
> In our particular case since we have many subfolders we need to use the ** wildcard to avoid coping them
I added the publish folder that is where we did our publishing test to check that every change we make is ok
```
/bin
/obj
/publish
**/bin
**/obj
```