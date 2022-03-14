public delegate void CallBack();
public delegate void CallBack<in T>(T arg);
public delegate void CallBack<in T, in X>(T arg1, X arg2);
public delegate void CallBack<in T, in X, in Y>(T arg1, X arg2, Y arg3);
public delegate void CallBack<in T, in X, in Y, in Z>(T arg1, X arg2, Y arg3, Z arg4);
public delegate void CallBack<in T, in X, in Y, in Z, in W>(T arg1, X arg2, Y arg3, Z arg4, W arg5);