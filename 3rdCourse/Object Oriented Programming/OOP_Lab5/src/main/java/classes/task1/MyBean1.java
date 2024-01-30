package classes.task1;

import jakarta.inject.Named;

@Named
public class MyBean1 {

private String msg;

String getMsg(){ return msg;}

void setMsg(String msg){this.msg=msg;}

}
