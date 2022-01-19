If you see this error on linux:<br>
Error: ENOSPC: System limit for number of file watchers reached <br>
Do this:<br>
`echo fs.inotify.max_user_watches=16384 | sudo tee -a /etc/sysctl.conf && sudo sysctl -p`
