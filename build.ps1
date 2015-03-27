#####                     #####
#     PsakeTest Build File    #
#####                     #####

Task default -depends compile

Task compile {
    msbuild
}